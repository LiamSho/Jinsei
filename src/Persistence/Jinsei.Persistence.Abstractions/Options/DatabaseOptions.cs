using Jinsei.Persistence.Abstractions.Enums;

namespace Jinsei.Persistence.Abstractions.Options;

/// <summary>
///     Database connection options.
/// </summary>
public sealed record DatabaseOptions
{
    /// <summary>
    ///     The database type.
    /// </summary>
    public DatabaseType Type { get; set; }

    /// <summary>
    ///     The database file path. Only used for SQLite.
    /// </summary>
    public string? File { get; set; }

    /// <summary>
    ///     The database host.
    /// </summary>
    public string? Host { get; set; }

    /// <summary>
    ///     The database port.
    /// </summary>
    public int? Port { get; set; }

    /// <summary>
    ///     The database name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     The database user.
    /// </summary>
    public string? User { get; set; }

    /// <summary>
    ///     The database password.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    ///     Extra connection string parameters.
    /// </summary>
    public string? Extra { get; set; }

    /// <summary>
    ///     The database connection string.
    /// </summary>
    public string? ConnectionString { get; set; }
}
