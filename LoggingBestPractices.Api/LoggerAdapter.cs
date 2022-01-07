namespace LoggingBestPractices.Api;

public class LoggerAdapter<T> : ILoggerAdapter<T>
{
    private readonly ILogger<T> _logger;

    public LoggerAdapter(ILogger<T> logger)
    {
        _logger = logger;
    }

    public void LogInformation(string message)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(message);
        }
    }

    public void LogInformation<T0>(string message, T0 args0)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(message,args0);
        }
    }
}

public interface ILoggerAdapter<T>
{
    void LogInformation(string message);
    void LogInformation<T0>(string message, T0 args0);
    
    // and so on 
}