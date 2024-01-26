namespace RestaurantApp.Order.LoggerService.Interfaces;


public interface ILoggerManager
{
    void LogDebug(string message);
    void LogInfo (string message);
    void LogWarn(string message);
    void LogError(string message);
}