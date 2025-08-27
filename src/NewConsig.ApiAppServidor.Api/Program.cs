using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using NewConsig.ApiAppServidor.Application.Services;
using NewConsig.ApiAppServidor.Application.Services.Interfaces;
using NewConsig.ApiAppServidor.Domain.Repositories;
using NewConsig.ApiAppServidor.Infrastructure.Data;
using NewConsig.ApiAppServidor.Infrastructure.Repositories;
using NewConsig.ApiAppServidor.Service.Service;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection("Database"));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAppDbContextFactory, DynamicDbContextFactory>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IConsignacaoRepository, ConsignacaoRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IConsignacaoService, ConsignacaoService>();
builder.Services.AddScoped<ITokenServico, TokenServico>();

builder.Services.AddHttpClient();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; // Lida com referências cíclicas
        options.JsonSerializerOptions.WriteIndented = true; // Para facilitar a leitura do JSON
        options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
    })
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.Formatting = Formatting.Indented;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "newconsigapi", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description =
                        "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
                        "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
                        "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
});
var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
