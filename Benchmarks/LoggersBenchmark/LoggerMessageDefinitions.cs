namespace LoggersBenchmark;

using Microsoft.Extensions.Logging;

public static class LoggerMessageDefinitions
{
    private static readonly Action<ILogger, int, string, MyClass, Exception?> InfoMessageDefinition =
        LoggerMessage.Define<int, string, MyClass>(LogLevel.Information, new EventId(0, "Benchmark"),
            "Logging: {someInteger} | {someString} | {@someClass}", new LogDefineOptions { SkipEnabledCheck = true });

    private static readonly Action<ILogger, int, string, MyClass, Exception?> WarnMessageDefinition =
        LoggerMessage.Define<int, string, MyClass>(LogLevel.Warning, new EventId(0, "Benchmark"),
            "Logging: {someInteger} | {someString} | {@someClass}", new LogDefineOptions { SkipEnabledCheck = true });

    public static void InformationWithDefinition(this ILogger logger, int someInteger, string someString, MyClass someClass)
    {
        InfoMessageDefinition(logger, someInteger, someString, someClass, null);
    }

    public static void WarningWithDefinition(this ILogger logger, int someInteger, string someString, MyClass someClass)
    {
        WarnMessageDefinition(logger, someInteger, someString, someClass, null);
    }
}
