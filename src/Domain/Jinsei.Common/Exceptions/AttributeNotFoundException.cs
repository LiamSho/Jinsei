namespace Jinsei.Common.Exceptions;

/// <summary>
///     Attribute not found exception.
/// </summary>
public sealed class AttributeNotFoundException : Exception
{
    /// <summary>
    ///     Attribute not found exception.
    /// </summary>
    /// <param name="sourceType"></param>
    /// <param name="attributeType"></param>
    public AttributeNotFoundException(Type sourceType, Type attributeType)
        : base($"{attributeType.FullName} does not exist on type {sourceType.FullName}")
    { }
}
