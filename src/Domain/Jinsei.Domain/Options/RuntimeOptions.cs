namespace Jinsei.Domain.Options;

/// <summary>
///     The runtime options.
/// </summary>
public sealed record RuntimeOptions
{
    /// <summary>
    ///     Runtime environment.
    /// </summary>
    public string Environment { get; set; } = "Production";

    /// <summary>
    ///     Whether the runtime environment is development.
    /// </summary>
    public bool IsDevelopment => Environment == "Development";

    /// <summary>
    ///     Whether the runtime environment is production.
    /// </summary>
    public bool IsProduction => Environment == "Production";
}
