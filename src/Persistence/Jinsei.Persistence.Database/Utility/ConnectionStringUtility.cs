using System.Text;
using Jinsei.Persistence.Abstractions.Enums;
using Jinsei.Persistence.Abstractions.Options;

namespace Jinsei.Persistence.Database.Utility;

/// <summary>
///     Connection string utility.
/// </summary>
public static class ConnectionStringUtility
{
    /// <summary>
    ///     Get connection string.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public static string GetConnectionString(this DatabaseOptions options)
    {
        if (string.IsNullOrEmpty(options.ConnectionString) is false)
        {
            return options.ConnectionString;
        }

        var connectionStringBuilder = new StringBuilder();

        switch (options.Type)
        {
            case DatabaseType.SQLite:
                connectionStringBuilder.Append($"Data Source={options.File};Version=3;");
                if (string.IsNullOrEmpty(options.Password) is false)
                {
                    connectionStringBuilder.Append($"Password={options.Password};");
                }
                break;
            case DatabaseType.MicrosoftSQLServer:
                connectionStringBuilder.Append(
                    $"Server={options.Host},{options.Port};Database={options.Name};User Id={options.User};Password={options.Password};");
                break;
            case DatabaseType.Postgres:
                connectionStringBuilder.Append(
                    $"Server={options.Host};Port={options.Port};Database={options.Name};User Id={options.User};Password={options.Password};");
                break;
            case DatabaseType.MySql:
                connectionStringBuilder.Append(
                    $"Server={options.Host};Port={options.Port};Database={options.Name};User Id={options.User};Password={options.Password};");
                break;
            default:
                throw new OverflowException($"Unknown database type {options.Type}.");
        }

        if (string.IsNullOrEmpty(options.Extra) is false)
        {
            connectionStringBuilder.Append(options.Extra);
        }

        return connectionStringBuilder.ToString();
    }
}
