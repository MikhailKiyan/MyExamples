namespace LoggersBenchmark;

using Serilog;

public static class InterpoletedStringHandlerLogger
{
    public static void InformationWithInterpoletedString(
            this ILogger logger,
            ref InterpoletedStringHandler handler) 
    {
        logger.Information(handler.ToString(), handler.Parameters.ToArray());
    }

    public static void WarningWithInterpoletedString(
           this ILogger logger,
           ref InterpoletedStringHandler handler)
    {
        logger.Warning(handler.ToString(), handler.Parameters.ToArray());
    }
}
