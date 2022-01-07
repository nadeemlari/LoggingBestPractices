using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.Benchmarks;

[MemoryDiagnoser]
public class BenchMarker
{
    private const string LogMessage = "This is a log message";
    private const string LogMessageWithParameters = "This is a log message with parameters {0} and {1}";

    private readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole().SetMinimumLevel(LogLevel.Warning);
    });

    private readonly ILogger<BenchMarker> _logger;

    public BenchMarker()
    {
        _logger = new Logger<BenchMarker>(_loggerFactory);
    }

    [Benchmark]
    public void Log_WithoutIf()
    {
        _logger.LogInformation(LogMessage);
    }
    [Benchmark]
    public void Log_WithIf()
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(LogMessage);
        }
        
    }
    [Benchmark]
    public void Log_WithoutIf_Parameters()
    {
        _logger.LogInformation(LogMessageWithParameters,23,56);
    }
    [Benchmark]
    public void Log_WithIf_Parameters()
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(LogMessageWithParameters,23,56);
        }
        
    }
    
    [Benchmark]
    public void Log_StringInterpolation()
    {
        _logger.LogInformation($"this is interpolation {0}",12);
    }
    [Benchmark]
    public void Log_StringTemplate()
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation("this is template {Number}",12);
        }
        
    }
    
}