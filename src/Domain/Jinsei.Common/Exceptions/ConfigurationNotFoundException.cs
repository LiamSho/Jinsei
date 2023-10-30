namespace Jinsei.Common.Exceptions;

/// <summary>
///     Exception thrown when a configuration is not found.
/// </summary>
public sealed class ConfigurationNotFoundException : Exception
{
    /// <summary>
    ///     Exception thrown when a configuration is not found.
    /// </summary>
    /// <param name="section"></param>
    /// <param name="bindType"></param>
    public ConfigurationNotFoundException(string section, Type bindType)
        : base($"Can not bind configuration section {section} to type {bindType.FullName}")
    { }
}
