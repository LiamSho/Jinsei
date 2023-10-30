namespace Jinsei.Domain.Extensions;

/// <summary>
///     Extension methods for attributes.
/// </summary>
public static class AttributeExtension
{
    /// <summary>
    ///     Gets the attribute on the specified type.
    /// </summary>
    /// <param name="type"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T? GetAttribute<T>(this Type type) where T : class
    {
        return type
            .GetCustomAttributes(typeof(T), false)
            .Cast<T>()
            .FirstOrDefault();
    }

    /// <summary>
    ///     Gets the attributes on the specified type.
    /// </summary>
    /// <param name="type"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T> GetAttributes<T>(this Type type) where T : class
    {
        return type
            .GetCustomAttributes(typeof(T), false)
            .Cast<T>();
    }
}
