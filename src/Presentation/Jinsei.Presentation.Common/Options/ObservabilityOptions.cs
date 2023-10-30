using Jinsei.Common.Attributes;

namespace Jinsei.Presentation.Common.Options;

/// <summary>
///     Observability options.
/// </summary>
[OptionName("Observability")]
public sealed record ObservabilityOptions
{
    /// <summary>
    ///     Gets or sets a value indicating whether to enable tracer.
    /// </summary>
    public bool EnableTracer { get; set; }

    /// <summary>
    ///     Gets or sets the tracer options.
    /// </summary>
    public TracerOptions? Tracer { get; set; }
}

/// <summary>
///     Tracer options.
/// </summary>
public sealed record TracerOptions
{
}
