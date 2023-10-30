using Jinsei.Common.Options;
using Jinsei.Persistence.Abstractions;
using Jinsei.Persistence.Abstractions.Enums;
using Jinsei.Persistence.Abstractions.Options;
using Jinsei.Persistence.Database.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Jinsei.Persistence.Database;

/// <summary>
///     The Jinsei EF Core Database context.
/// </summary>
public class JinseiDbContext : DbContext, IJinseiDbContext
{
    private readonly IOptions<DatabaseOptions> _databaseOptions;
    private readonly IOptions<RuntimeOptions> _runtimeOptions;

    /// <summary>
    ///     Initializes a new instance of the <see cref="JinseiDbContext" /> class.
    /// </summary>
    /// <param name="databaseOptions"></param>
    /// <param name="runtimeOptions"></param>
    public JinseiDbContext(
        IOptions<DatabaseOptions> databaseOptions,
        IOptions<RuntimeOptions> runtimeOptions)
    {
        _databaseOptions = databaseOptions;
        _runtimeOptions = runtimeOptions;
    }

    /// <inheritdoc />
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        switch (_databaseOptions.Value.Type)
        {
            case DatabaseType.SQLite:
                optionsBuilder
                    .UseSqlite(_databaseOptions.Value.GetConnectionString());
                break;
            case DatabaseType.MicrosoftSQLServer:
                optionsBuilder
                    .UseSqlServer(_databaseOptions.Value.GetConnectionString());
                break;
            case DatabaseType.Postgres:
                optionsBuilder
                    .UseNpgsql(_databaseOptions.Value.GetConnectionString())
                    .UseSnakeCaseNamingConvention();
                break;
            case DatabaseType.MySql:
                optionsBuilder
                    .UseMySql(
                        _databaseOptions.Value.GetConnectionString(),
                        ServerVersion.AutoDetect(_databaseOptions.Value.GetConnectionString()));
                break;
            default:
                throw new OverflowException($"Unknown database type {_databaseOptions.Value.Type}.");
        }

        optionsBuilder.UseSnakeCaseNamingConvention();

        if (_runtimeOptions.Value.IsDevelopment)
        {
            optionsBuilder
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();
        }
    }
}
