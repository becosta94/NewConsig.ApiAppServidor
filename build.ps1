param(
  [string]$SolutionName = "NewConsig.ApiAppServidor"
)

$ErrorActionPreference = "Stop"

# Estrutura de pastas raiz
New-Item -ItemType Directory -Force -Path "src" | Out-Null
New-Item -ItemType Directory -Force -Path "docker" | Out-Null

# Garantir pastas de projetos
New-Item -ItemType Directory -Force -Path "src/NewConsig.ApiAppServidor.Domain" | Out-Null
New-Item -ItemType Directory -Force -Path "src/NewConsig.ApiAppServidor.Application" | Out-Null
New-Item -ItemType Directory -Force -Path "src/NewConsig.ApiAppServidor.Infrastructure" | Out-Null
New-Item -ItemType Directory -Force -Path "src/NewConsig.ApiAppServidor.Api" | Out-Null

# Subpastas
New-Item -ItemType Directory -Force -Path "src/NewConsig.ApiAppServidor.Api/Controllers" | Out-Null
New-Item -ItemType Directory -Force -Path "src/NewConsig.ApiAppServidor.Infrastructure/Data" | Out-Null
New-Item -ItemType Directory -Force -Path "src/NewConsig.ApiAppServidor.Infrastructure/Repositories" | Out-Null
New-Item -ItemType Directory -Force -Path "src/NewConsig.ApiAppServidor.Infrastructure/Tenancy" | Out-Null
New-Item -ItemType Directory -Force -Path "src/NewConsig.ApiAppServidor.Infrastructure/Migrations" | Out-Null
New-Item -ItemType Directory -Force -Path "src/NewConsig.ApiAppServidor.Application/DTOs" | Out-Null
New-Item -ItemType Directory -Force -Path "src/NewConsig.ApiAppServidor.Application/Services" | Out-Null
New-Item -ItemType Directory -Force -Path "src/NewConsig.ApiAppServidor.Domain/Entities" | Out-Null
New-Item -ItemType Directory -Force -Path "src/NewConsig.ApiAppServidor.Domain/Repositories" | Out-Null

# Solution
@"
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.9.34728.123
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "NewConsig.ApiAppServidor.Api", "src\NewConsig.ApiAppServidor.Api\NewConsig.ApiAppServidor.Api.csproj", "{8F7CB4C6-7E2E-4C8D-9A5B-6EFA7D7B41B0}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "NewConsig.ApiAppServidor.Application", "src\NewConsig.ApiAppServidor.Application\NewConsig.ApiAppServidor.Application.csproj", "{A2C5D88C-14E2-4D7F-9B3F-72E0A2B1A8B8}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "NewConsig.ApiAppServidor.Domain", "src\NewConsig.ApiAppServidor.Domain\NewConsig.ApiAppServidor.Domain.csproj", "{B7B6D6B1-2C6C-4B5E-9F63-2E5F6C6D3A3A}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "NewConsig.ApiAppServidor.Infrastructure", "src\NewConsig.ApiAppServidor.Infrastructure\NewConsig.ApiAppServidor.Infrastructure.csproj", "{C91C7B84-41C3-4C5B-9D9C-7C3A6FB9AEE3}"
EndProject
Global
  GlobalSection(SolutionConfigurationPlatforms) = preSolution
    Debug|Any CPU = Debug|Any CPU
    Release|Any CPU = Release|Any CPU
  EndGlobalSection
  GlobalSection(ProjectConfigurationPlatforms) = postSolution
    {8F7CB4C6-7E2E-4C8D-9A5B-6EFA7D7B41B0}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
    {8F7CB4C6-7E2E-4C8D-9A5B-6EFA7D7B41B0}.Debug|Any CPU.Build.0 = Debug|Any CPU
    {8F7CB4C6-7E2E-4C8D-9A5B-6EFA7D7B41B0}.Release|Any CPU.ActiveCfg = Release|Any CPU
    {8F7CB4C6-7E2E-4C8D-9A5B-6EFA7D7B41B0}.Release|Any CPU.Build.0 = Release|Any CPU
    {A2C5D88C-14E2-4D7F-9B3F-72E0A2B1A8B8}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
    {A2C5D88C-14E2-4D7F-9B3F-72E0A2B1A8B8}.Debug|Any CPU.Build.0 = Debug|Any CPU
    {A2C5D88C-14E2-4D7F-9B3F-72E0A2B1A8B8}.Release|Any CPU.ActiveCfg = Release|Any CPU
    {A2C5D88C-14E2-4D7F-9B3F-72E0A2B1A8B8}.Release|Any CPU.Build.0 = Release|Any CPU
    {B7B6D6B1-2C6C-4B5E-9F63-2E5F6C6D3A3A}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
    {B7B6D6B1-2C6C-4B5E-9F63-2E5F6C6D3A3A}.Debug|Any CPU.Build.0 = Debug|Any CPU
    {B7B6D6B1-2C6C-4B5E-9F63-2E5F6C6D3A3A}.Release|Any CPU.ActiveCfg = Release|Any CPU
    {B7B6D6B1-2C6C-4B5E-9F63-2E5F6C6D3A3A}.Release|Any CPU.Build.0 = Release|Any CPU
    {C91C7B84-41C3-4C5B-9D9C-7C3A6FB9AEE3}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
    {C91C7B84-41C3-4C5B-9D9C-7C3A6FB9AEE3}.Debug|Any CPU.Build.0 = Debug|Any CPU
    {C91C7B84-41C3-4C5B-9D9C-7C3A6FB9AEE3}.Release|Any CPU.ActiveCfg = Release|Any CPU
    {C91C7B84-41C3-4C5B-9D9C-7C3A6FB9AEE3}.Release|Any CPU.Build.0 = Release|Any CPU
  EndGlobalSection
EndGlobal
"@ | Set-Content -Path "$SolutionName.sln" -Encoding UTF8

# csproj Domain
@"
<Project Sdk=""Microsoft.NET.Sdk"">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>
</Project>
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Domain/NewConsig.ApiAppServidor.Domain.csproj"

# Domain files
@"
namespace NewConsig.ApiAppServidor.Domain.Entities;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Domain/Entities/Cliente.cs"

@"
using NewConsig.ApiAppServidor.Domain.Entities;

namespace NewConsig.ApiAppServidor.Domain.Repositories;

public interface IClienteRepository
{
    Task<Cliente?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<List<Cliente>> GetAllAsync(CancellationToken ct = default);
    Task<Cliente> AddAsync(Cliente entity, CancellationToken ct = default);
    Task UpdateAsync(Cliente entity, CancellationToken ct = default);
    Task DeleteAsync(int id, CancellationToken ct = default);
}
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Domain/Repositories/IClienteRepository.cs"

# Application csproj
@"
<Project Sdk=""Microsoft.NET.Sdk"">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>
  <ItemGroup>
    <ProjectReference Include=""..\NewConsig.ApiAppServidor.Domain\NewConsig.ApiAppServidor.Domain.csproj"" />
  </ItemGroup>
</Project>
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Application/NewConsig.ApiAppServidor.Application.csproj"

# Application files
@"
namespace NewConsig.ApiAppServidor.Application.DTOs;

public record ClienteDto(int Id, string Nome, string Email);
public record CreateClienteRequest(string Nome, string Email);
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Application/DTOs/ClienteDto.cs"

@"
using NewConsig.ApiAppServidor.Application.DTOs;

namespace NewConsig.ApiAppServidor.Application.Services;

public interface IClienteService
{
    Task<ClienteDto?> GetAsync(int id, CancellationToken ct = default);
    Task<List<ClienteDto>> ListAsync(CancellationToken ct = default);
    Task<ClienteDto> CreateAsync(CreateClienteRequest req, CancellationToken ct = default);
    Task UpdateAsync(int id, CreateClienteRequest req, CancellationToken ct = default);
    Task DeleteAsync(int id, CancellationToken ct = default);
}
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Application/Services/IClienteService.cs"

@"
using NewConsig.ApiAppServidor.Application.DTOs;
using NewConsig.ApiAppServidor.Domain.Repositories;
using NewConsig.ApiAppServidor.Domain.Entities;

namespace NewConsig.ApiAppServidor.Application.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repo;

    public ClienteService(IClienteRepository repo) => _repo = repo;

    public async Task<ClienteDto?> GetAsync(int id, CancellationToken ct = default)
    {
        var c = await _repo.GetByIdAsync(id, ct);
        return c is null ? null : new ClienteDto(c.Id, c.Nome, c.Email);
    }

    public async Task<List<ClienteDto>> ListAsync(CancellationToken ct = default)
    {
        var list = await _repo.GetAllAsync(ct);
        return list.Select(c => new ClienteDto(c.Id, c.Nome, c.Email)).ToList();
    }

    public async Task<ClienteDto> CreateAsync(CreateClienteRequest req, CancellationToken ct = default)
    {
        var entity = new Cliente { Nome = req.Nome, Email = req.Email };
        entity = await _repo.AddAsync(entity, ct);
        return new ClienteDto(entity.Id, entity.Nome, entity.Email);
    }

    public async Task UpdateAsync(int id, CreateClienteRequest req, CancellationToken ct = default)
    {
        var c = await _repo.GetByIdAsync(id, ct) ?? throw new KeyNotFoundException(""Cliente não encontrado"");
        c.Nome = req.Nome;
        c.Email = req.Email;
        await _repo.UpdateAsync(c, ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        await _repo.DeleteAsync(id, ct);
    }
}
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Application/Services/ClienteService.cs"

# Infrastructure csproj
@"
<Project Sdk=""Microsoft.NET.Sdk"">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include=""Microsoft.EntityFrameworkCore.SqlServer"" Version=""8.0.6"" />
    <PackageReference Include=""Microsoft.EntityFrameworkCore.Design"" Version=""8.0.6"">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include=""..\NewConsig.ApiAppServidor.Domain\NewConsig.ApiAppServidor.Domain.csproj"" />
  </ItemGroup>
</Project>
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Infrastructure/NewConsig.ApiAppServidor.Infrastructure.csproj"

# Infrastructure files
@"
using Microsoft.EntityFrameworkCore;
using NewConsig.ApiAppServidor.Domain.Entities;

namespace NewConsig.ApiAppServidor.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Cliente> Clientes => Set<Cliente>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(e =>
        {
            e.ToTable(""Clientes"");
            e.HasKey(x => x.Id);
            e.Property(x => x.Nome).HasMaxLength(200).IsRequired();
            e.Property(x => x.Email).HasMaxLength(200).IsRequired();
            e.Property(x => x.CriadoEm).HasDefaultValueSql(""GETUTCDATE()"");
        });
    }
}
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Infrastructure/Data/AppDbContext.cs"

@"
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NewConsig.ApiAppServidor.Infrastructure.Tenancy;

namespace NewConsig.ApiAppServidor.Infrastructure.Data;

public class DatabaseOptions
{
    public string BaseConnectionString { get; set; } = default!;
    public string? DefaultDatabase { get; set; }
}

public interface IAppDbContextFactory
{
    AppDbContext CreateDbContext();
}

public class DynamicDbContextFactory : IAppDbContextFactory
{
    private readonly ITenantProvider _tenantProvider;
    private readonly DatabaseOptions _dbOpts;

    public DynamicDbContextFactory(ITenantProvider tenantProvider, IOptions<DatabaseOptions> dbOpts)
    {
        _tenantProvider = tenantProvider;
        _dbOpts = dbOpts.Value;
    }

    public AppDbContext CreateDbContext()
    {
        var database = _tenantProvider.GetDatabaseName() ?? _dbOpts.DefaultDatabase;
        if (string.IsNullOrWhiteSpace(database))
            throw new InvalidOperationException(""Banco de dados não informado."");

        var cs = BuildConnectionString(_dbOpts.BaseConnectionString, database);

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(cs, o =>
        {
            o.EnableRetryOnFailure();
            o.MigrationsHistoryTable(""__EFMigrationsHistory"", schema: null);
        });

        return new AppDbContext(optionsBuilder.Options);
    }

    private static string BuildConnectionString(string baseCs, string database)
    {
        var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(baseCs)
        {
            InitialCatalog = database
        };
        return builder.ConnectionString;
    }
}
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Infrastructure/Data/DynamicDbContextFactory.cs"

@"
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NewConsig.ApiAppServidor.Infrastructure.Data;

public class DesignTimeFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(""Server=localhost;Database=DesignTimeDb;Trusted_Connection=True;TrustServerCertificate=True;"");
        return new AppDbContext(optionsBuilder.Options);
    }
}
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Infrastructure/Data/DesignTimeFactory.cs"

@"
using Microsoft.EntityFrameworkCore;
using NewConsig.ApiAppServidor.Domain.Entities;
using NewConsig.ApiAppServidor.Domain.Repositories;
using NewConsig.ApiAppServidor.Infrastructure.Data;

namespace NewConsig.ApiAppServidor.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly IAppDbContextFactory _ctxFactory;

    public ClienteRepository(IAppDbContextFactory ctxFactory) => _ctxFactory = ctxFactory;

    public async Task<Cliente?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        using var ctx = _ctxFactory.CreateDbContext();
        return await ctx.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task<List<Cliente>> GetAllAsync(CancellationToken ct = default)
    {
        using var ctx = _ctxFactory.CreateDbContext();
        return await ctx.Clientes.AsNoTracking().OrderBy(x => x.Id).ToListAsync(ct);
    }

    public async Task<Cliente> AddAsync(Cliente entity, CancellationToken ct = default)
    {
        using var ctx = _ctxFactory.CreateDbContext();
        ctx.Clientes.Add(entity);
        await ctx.SaveChangesAsync(ct);
        return entity;
    }

    public async Task UpdateAsync(Cliente entity, CancellationToken ct = default)
    {
        using var ctx = _ctxFactory.CreateDbContext();
        ctx.Clientes.Update(entity);
        await ctx.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        using var ctx = _ctxFactory.CreateDbContext();
        var c = await ctx.Clientes.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (c is null) return;
        ctx.Clientes.Remove(c);
        await ctx.SaveChangesAsync(ct);
    }
}
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Infrastructure/Repositories/ClienteRepository.cs"

@"
namespace NewConsig.ApiAppServidor.Infrastructure.Tenancy;

public interface ITenantProvider
{
    string? GetDatabaseName();
}
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Infrastructure/Tenancy/ITenantProvider.cs"

@"
using Microsoft.AspNetCore.Http;

namespace NewConsig.ApiAppServidor.Infrastructure.Tenancy;

public class HttpTenantProvider : ITenantProvider
{
    private readonly IHttpContextAccessor _http;

    public HttpTenantProvider(IHttpContextAccessor http) => _http = http;

    public string? GetDatabaseName()
    {
        var ctx = _http.HttpContext;
        if (ctx is null) return null;

        if (ctx.Request.Headers.TryGetValue(""X-Database"", out var h) && !string.IsNullOrWhiteSpace(h))
            return h.ToString();

        if (ctx.Request.Query.TryGetValue(""db"", out var q) && !string.IsNullOrWhiteSpace(q))
            return q.ToString();

        return null;
    }
}
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Infrastructure/Tenancy/HttpTenantProvider.cs"

# Migrations
@"
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewConsig.ApiAppServidor.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: ""Clientes"",
                columns: table => new
                {
                    Id = table.Column<int>(type: ""int"", nullable: false)
                        .Annotation(""SqlServer:Identity"", ""1, 1""),
                    Nome = table.Column<string>(type: ""nvarchar(200)"", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: ""nvarchar(200)"", maxLength: 200, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: ""datetime2"", nullable: false, defaultValueSql: ""GETUTCDATE()"")
                },
                constraints: table =>
                {
                    table.PrimaryKey(""PK_Clientes"", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: ""Clientes"");
        }
    }
}
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Infrastructure/Migrations/20250819000100_Initial.cs"

@"
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewConsig.ApiAppServidor.Infrastructure.Data;

#nullable disable

namespace NewConsig.ApiAppServidor.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation(""ProductVersion"", ""8.0.6"")
                .HasAnnotation(""Relational:MaxIdentifierLength"", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity(""NewConsig.ApiAppServidor.Domain.Entities.Cliente"", b =>
                {
                    b.Property<int>(""Id"")
                        .ValueGeneratedOnAdd()
                        .HasColumnType(""int"");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>(""Id""));

                    b.Property<DateTime>(""CriadoEm"")
                        .ValueGeneratedOnAdd()
                        .HasColumnType(""datetime2"")
                        .HasDefaultValueSql(""GETUTCDATE()"");

                    b.Property<string>(""Email"")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType(""nvarchar(200)"");

                    b.Property<string>(""Nome"")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType(""nvarchar(200)"");

                    b.HasKey(""Id"");

                    b.ToTable(""Clientes"", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Infrastructure/Migrations/AppDbContextModelSnapshot.cs"

# API csproj
@"
<Project Sdk=""Microsoft.NET.Sdk.Web"">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include=""Swashbuckle.AspNetCore"" Version=""6.5.0"" />
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include=""..\NewConsig.ApiAppServidor.Application\NewConsig.ApiAppServidor.Application.csproj"" />
    <ProjectReference Include=""..\NewConsig.ApiAppServidor.Infrastructure\NewConsig.ApiAppServidor.Infrastructure.csproj"" />
  </ItemGroup>
</Project>
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Api/NewConsig.ApiAppServidor.Api.csproj"

# Program.cs
@"
using NewConsig.ApiAppServidor.Application.Services;
using NewConsig.ApiAppServidor.Domain.Repositories;
using NewConsig.ApiAppServidor.Infrastructure.Data;
using NewConsig.ApiAppServidor.Infrastructure.Repositories;
using NewConsig.ApiAppServidor.Infrastructure.Tenancy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection(""Database""));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ITenantProvider, HttpTenantProvider>();
builder.Services.AddScoped<IAppDbContextFactory, DynamicDbContextFactory>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Api/Program.cs"

# Controller
@"
using Microsoft.AspNetCore.Mvc;
using NewConsig.ApiAppServidor.Application.Services;
using NewConsig.ApiAppServidor.Application.DTOs;

namespace NewConsig.ApiAppServidor.Api.Controllers;

[ApiController]
[Route(""api/clientes"")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _service;

    public ClientesController(IClienteService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<List<ClienteDto>>> GetAll(CancellationToken ct)
    {
        var list = await _service.ListAsync(ct);
        return Ok(list);
    }

    [HttpGet(""{id:int}"")]
    public async Task<ActionResult<ClienteDto>> GetById(int id, CancellationToken ct)
    {
        var c = await _service.GetAsync(id, ct);
        if (c is null) return NotFound();
        return Ok(c);
    }

    [HttpPost]
    public async Task<ActionResult<ClienteDto>> Create([FromBody] CreateClienteRequest req, CancellationToken ct)
    {
        var created = await _service.CreateAsync(req, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut(""{id:int}"")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateClienteRequest req, CancellationToken ct)
    {
        await _service.UpdateAsync(id, req, ct);
        return NoContent();
    }

    [HttpDelete(""{id:int}"")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await _service.DeleteAsync(id, ct);
        return NoContent();
    }
}
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Api/Controllers/ClientesController.cs"

# appsettings
@"
{
  ""Database"": {
    ""BaseConnectionString"": ""Server=localhost;Trusted_Connection=True;TrustServerCertificate=True;"",
    ""DefaultDatabase"": ""MinhaBasePadrao""
  },
  ""Logging"": {
    ""LogLevel"": {
      ""Default"": ""Information"",
      ""Microsoft.AspNetCore"": ""Warning""
    }
  },
  ""AllowedHosts"": ""*""
}
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Api/appsettings.json"

@"
{
  ""Database"": {
    ""BaseConnectionString"": ""Server=localhost;Trusted_Connection=True;TrustServerCertificate=True;"",
    ""DefaultDatabase"": ""MinhaBasePadrao""
  }
}
"@ | Set-Content -Path "src/NewConsig.ApiAppServidor.Api/appsettings.Development.json"

# docker-compose
@"
version: ""3.9""
services:
  sqlserver:
    image: mcr.microsoft.com/mssql/server:2022-latest
    container_name: newconsig-sqlserver
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=YourStrong!Passw0rd
    ports:
      - ""1433:1433""
    volumes:
      - sqldata:/var/opt/mssql
    healthcheck:
      test: [""CMD-SHELL"", ""/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P $$SA_PASSWORD -C -Q 'SELECT 1'""]
      interval: 10s
      timeout: 5s
      retries: 10
volumes:
  sqldata:
"@ | Set-Content -Path "docker/docker-compose.yml"

# README
@"
# NewConsig.ApiAppServidor

API .NET 8 em camadas com EF Core SQL Server e seleção dinâmica de banco por requisição (X-Database ou ?db=).

## Build e Run
dotnet restore
dotnet build
dotnet run --project src/NewConsig.ApiAppServidor.Api

## Migrations
dotnet tool install --global dotnet-ef
dotnet ef migrations add Initial -p src/NewConsig.ApiAppServidor.Infrastructure -s src/NewConsig.ApiAppServidor.Api
dotnet ef database update -p src/NewConsig.ApiAppServidor.Infrastructure -s src/NewConsig.ApiAppServidor.Api
"@ | Set-Content -Path "README.md"

# Zip
$zipPath = Join-Path (Get-Location) "NewConsig.ApiAppServidor.zip"
if (Test-Path $zipPath) { Remove-Item $zipPath -Force }
Compress-Archive -Path * -DestinationPath $zipPath

Write-Host "Zip gerado em $zipPath"