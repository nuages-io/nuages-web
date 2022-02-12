// ReSharper disable UnusedMember.Global

using System.Runtime.CompilerServices;

namespace Nuages.Web;

// ReSharper disable once UnusedType.Global
public class TraceMonitor : ITraceMonitor
{
    private readonly ILogger<TraceMonitor> _logger;

    public TraceMonitor(ILogger<TraceMonitor> logger)
    {
        _logger = logger;
    }
    
    public void BeginSegment([CallerMemberName] string name = "", DateTime? timestamp = null)
    {
        _logger.LogInformation($"Begin segment {name} {timestamp}");
    }

    public void EndSegment()
    {
        _logger.LogInformation("End semgment");
    }

    public void LogException(Exception exception)
    {
        _logger.LogError(exception.Message);
    }
}

public interface ITraceMonitor
{
    void BeginSegment([CallerMemberName] string name = "", DateTime? timestamp = null);
    void EndSegment();
    void LogException(Exception exception);
}