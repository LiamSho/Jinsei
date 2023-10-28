using Jinsei.Persistence.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Jinsei.Persistence.Database;

/// <summary>
///     Extension methods for Database persistence.
/// </summary>
public static class DatabasePersistenceExtension
{
    /// <summary>
    ///     Add Jinsei database context.
    /// </summary>
    /// <param name="services"></param>
    public static void AddJinseiDbContext(this IServiceCollection services)
    {
        services.AddDbContext<IJinseiDbContext, JinseiDbContext>();
    }
}
