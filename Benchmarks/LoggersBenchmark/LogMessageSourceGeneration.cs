namespace LoggersBenchmark;

using Microsoft.Extensions.Logging;

public static partial class LogMessageSourceGeneration
{
    [LoggerMessage(EventId = 0, EventName = "Benchmark", Level = LogLevel.Information,
        Message = "Logging: {someInteger} | {someString} | {someClass}", SkipEnabledCheck = true)]
    public static partial void InformationWithSourceGeneration(this ILogger logger,
        int someInteger, string someString, MyClass someClass);

    [LoggerMessage(EventId = 0, EventName = "Benchmark", Level = LogLevel.Warning,
    Message = "Logging: {someInteger} | {someString} | {someClass}", SkipEnabledCheck = true)]
    public static partial void WarningWithSourceGeneration(this ILogger logger,
        int someInteger, string someString, MyClass someClass);
}
