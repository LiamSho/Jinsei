using Jinsei.Common.Extensions;
using Jinsei.Presentation.Common.Enrichers;
using Jinsei.Presentation.Common.Options;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Jinsei.Presentation.Common.Extensions;

/// <summary>
///     Extension methods for observability.
/// </summary>
public static class ObservabilityExtension
{
    /// <summary>
    ///     Gets the logger configuration.
    /// </summary>
    /// <returns></returns>
    public static LoggerConfiguration GetLoggerConfiguration(this IConfiguration configuration)
    {
        var observabilityOptions = configuration.GetOption<ObservabilityOptions>();

        var loggerConfiguration = new LoggerConfiguration();

        loggerConfiguration.ReadFrom
            .Configuration(configuration.GetSection("Observability:Logger"));

        loggerConfiguration.Enrich.FromLogContext();
        loggerConfiguration.Enrich.WithThreadId();
        loggerConfiguration.Enrich.With(new LoggerTraceIdEnricher(observabilityOptions.EnableTracer));

        return loggerConfiguration;
    }
}
