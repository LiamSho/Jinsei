namespace Jinsei.Common.Attributes;

/// <summary>
///     Attribute to specify the name of an option.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class OptionNameAttribute : Attribute
{
    /// <summary>
    ///     The name of the option.
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     Set the name of the option.
    /// </summary>
    /// <param name="name">The name of the option.</param>
    public OptionNameAttribute(string name)
    {
        Name = name;
    }
}
