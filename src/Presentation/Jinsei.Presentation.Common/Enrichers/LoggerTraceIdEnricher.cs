using System.Diagnostics;
using OpenTelemetry.Trace;
using Serilog.Core;
using Serilog.Events;

namespace Jinsei.Presentation.Common.Enrichers;

/// <summary>
///     Logger trace id enricher.
/// </summary>
public sealed class LoggerTraceIdEnricher : ILogEventEnricher
{
    private readonly bool _tracerEnabled;

    /// <summary>
    ///     Initializes a new instance of the <see cref="LoggerTraceIdEnricher" /> class.
    /// </summary>
    /// <param name="tracerEnabled"></param>
    public LoggerTraceIdEnricher(bool tracerEnabled)
    {
        _tracerEnabled = tracerEnabled;
    }

    /// <summary>
    ///     Enriches the log event with trace id.
    /// </summary>
    /// <param name="logEvent"></param>
    /// <param name="propertyFactory"></param>
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var traceId = _tracerEnabled
            ? Tracer.CurrentSpan.Context.TraceId.ToHexString()
            : (Activity.Current?.Id ?? string.Empty);

        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(
            "TraceId", traceId));
    }
}
