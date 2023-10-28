// ReSharper disable InconsistentNaming
namespace Jinsei.Persistence.Abstractions.Enums;

/// <summary>
///     The database type.
/// </summary>
public enum DatabaseType
{
    /// <summary>
    ///     SQLite database type.
    /// </summary>
    SQLite,

    /// <summary>
    ///     Microsoft SQL Server database type.
    /// </summary>
    MicrosoftSQLServer,

    /// <summary>
    ///     Postgres database type.
    /// </summary>
    Postgres,

    /// <summary>
    ///     MySQL database type.
    /// </summary>
    MySql
}
