using Jinsei.Common.Attributes;
using Jinsei.Common.Exceptions;
using Jinsei.Domain.Extensions;
using Microsoft.Extensions.Configuration;

namespace Jinsei.Common.Extensions;

/// <summary>
///     Extension methods for options.
/// </summary>
public static class OptionsExtension
{
    /// <summary>
    ///     Gets the option.
    /// </summary>
    /// <param name="configuration"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetOption<T>(this IConfiguration configuration)
    {
        var section = typeof(T).GetAttribute<OptionNameAttribute>();

        if (section is null)
        {
            throw new AttributeNotFoundException(typeof(T), typeof(OptionNameAttribute));
        }

        var option = configuration
            .GetSection(section.Name)
            .Get<T>();

        if (option is null)
        {
            throw new ConfigurationNotFoundException(section.Name, typeof(T));
        }

        return option;
    }
}
