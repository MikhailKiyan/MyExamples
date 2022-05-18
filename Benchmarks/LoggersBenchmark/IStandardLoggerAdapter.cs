namespace LoggersBenchmark
{
    public interface IStandardLoggerAdapter
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogInformation<T0>(string message, T0 arg0);
        void LogWarning<T0>(string message, T0 arg0);
        void LogInformation<T0, T1>(string message, T0 arg0, T1 arg1);
        void LogWarning<T0, T1>(string message, T0 arg0, T1 arg1);
        void LogInformation<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);
        void LogWarning<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);
    }
}
