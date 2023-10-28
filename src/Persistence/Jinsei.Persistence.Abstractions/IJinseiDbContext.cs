namespace Jinsei.Persistence.Abstractions;

/// <summary>
///     Interface for EF Core DB Context
/// </summary>
public interface IJinseiDbContext
{
    /// <summary>
    ///     Write changes to the database.
    /// </summary>
    /// <returns>The number of state entries written to the database.</returns>
    public int SaveChanges();

    /// <summary>
    ///     Write changes to the database.
    /// </summary>
    /// <param name="acceptAllChangesOnSuccess"></param>
    /// <returns>The number of state entries written to the database.</returns>
    public int SaveChanges(bool acceptAllChangesOnSuccess);

    /// <summary>
    ///     Write changes to the database.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>The number of state entries written to the database.</returns>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Write changes to the database.
    /// </summary>
    /// <param name="acceptAllChangesOnSuccess"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>The number of state entries written to the database.</returns>
    public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);
}
