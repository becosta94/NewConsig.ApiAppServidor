using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace NewConsig.ApiAppServidor.Infrastructure.Data;

public class DatabaseOptions
{
    public string BaseConnectionString { get; set; } = default!;
    public string? DefaultDatabase { get; set; }
}

public interface IAppDbContextFactory
{
    AppDbContext CreateDbContext(string databaseName);
}

public class DynamicDbContextFactory : IAppDbContextFactory
{
    private readonly DatabaseOptions _dbOpts;
    private readonly IConfiguration _configuration;


    public DynamicDbContextFactory(IOptions<DatabaseOptions> dbOpts, IConfiguration configuration)
    {
        _dbOpts = dbOpts.Value;
        _configuration = configuration;
    }

    public AppDbContext CreateDbContext(string databaseName)
    {

        //var cidadesPermitidas = _configuration.GetSection("CidadesHabilitadas").Value.get;
        var template = _configuration.GetConnectionString("BaseConnectionString");

        if (string.IsNullOrWhiteSpace(databaseName))
            throw new InvalidOperationException("Banco de dados não informado.");

        var cs = BuildConnectionString(_dbOpts.BaseConnectionString, databaseName);

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(cs, o =>
        {
            o.EnableRetryOnFailure();
            o.MigrationsHistoryTable("__EFMigrationsHistory", schema: null);
        });

        return new AppDbContext(optionsBuilder.Options);
    }

    private static string BuildConnectionString(string baseCs, string database)
    {
        var builder = new Microsoft.Data.SqlClient.SqlConnectionStringBuilder(baseCs)
        {
            InitialCatalog = database
        };
        return builder.ConnectionString;
    }
}
