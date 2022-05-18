using System.Runtime.CompilerServices;

namespace LoggersBenchmark;

[InterpolatedStringHandler]
public ref struct InterpoletedStringHandler
{
    private DefaultInterpolatedStringHandler innerHandler;

    public List<object?> Parameters { get; } = new();

    public InterpoletedStringHandler(int literalLength, int formattedCount)
    {
        innerHandler = new DefaultInterpolatedStringHandler(literalLength, formattedCount);
    }

    public void AppendLiteral(string message)
    {
        innerHandler.AppendLiteral(message);
    }

    public void AppendFormatted<T>(
            T message,
            [CallerArgumentExpression("message")] string callerName = "")
    {
        innerHandler.AppendFormatted("{" + callerName + "}");
        Parameters.Add(message);
    }

    public override string ToString() => innerHandler.ToString();

    public string ToStringAndClear() => innerHandler.ToStringAndClear();
}
