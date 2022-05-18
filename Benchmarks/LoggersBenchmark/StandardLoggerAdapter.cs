namespace LoggersBenchmark
{
    using Microsoft.Extensions.Logging;

    public class StandardLoggerAdapter<T> : IStandardLoggerAdapter
    {
        private ILogger<T> logger;

        private bool isEnabledInformationLevel;
        private bool isEnabledWarningLevel;

        public StandardLoggerAdapter(ILogger<T> logger)
        {
            ArgumentNullException.ThrowIfNull(logger, nameof(logger));
            this.logger = logger;
            isEnabledInformationLevel = logger.IsEnabled(LogLevel.Information);
            isEnabledWarningLevel = logger.IsEnabled(LogLevel.Warning);
        }

        public void LogInformation(string message)
        {
            if (isEnabledInformationLevel) this.logger.LogInformation(message);
        }

        public void LogInformation<T0>(string message, T0 arg0)
        {
            if (isEnabledInformationLevel) this.logger.LogInformation(message, arg0);
        }

        public void LogInformation<T0, T1>(string message, T0 arg0, T1 arg1)
        {
            if (isEnabledInformationLevel) this.logger.LogInformation(message, arg0, arg1);
        }

        public void LogInformation<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2)
        {
            if (isEnabledInformationLevel) this.logger.LogInformation(message, arg0, arg1, arg2);
        }

        public void LogWarning(string message)
        {
            if (isEnabledWarningLevel) this.logger.LogWarning(message);
        }

        public void LogWarning<T0>(string message, T0 arg0)
        {
            if (isEnabledWarningLevel) this.logger.LogWarning(message, arg0);
        }

        public void LogWarning<T0, T1>(string message, T0 arg0, T1 arg1)
        {
            if (isEnabledWarningLevel) this.logger.LogWarning(message, arg0, arg1);
        }

        public void LogWarning<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2)
        {
            if (isEnabledWarningLevel) this.logger.LogWarning(message, arg0, arg1, arg2);
        }
    }
}
