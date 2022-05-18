using MsLogging = Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;
using Serilog;
using BenchmarkDotNet.Running;
using LoggersBenchmark;

public class Program
{
    public const int SomeInteger = 5;
    public const string SomeString = "String";
    public static readonly MyClass SomeClass = new MyClass { Integer = SomeInteger, String = SomeString };
    public static readonly (int, string) SomeTople = new(SomeInteger, SomeString);

    private static readonly MsLogging.ILogger standartLogger;
    public static MsLogging.ILogger StandartLogger { get => standartLogger; }

    private static readonly IStandardLoggerAdapter standardLoggerAdapter;
    public static IStandardLoggerAdapter StandardLoggerAdapter { get => standardLoggerAdapter; }

    private static readonly Serilog.ILogger serialogLogger;
    public static Serilog.ILogger SerialogLogger { get => serialogLogger; }

    static Program()
    {
        using var loggerFactory = MsLogging.LoggerFactory.Create(config =>
        {
            config.AddFilter("Microsoft", MsLogging.LogLevel.Warning)
                  .AddFilter("System", MsLogging.LogLevel.Warning)
                  .AddFilter("NonHostConsoleApp.Program", MsLogging.LogLevel.Debug)
                  .SetMinimumLevel(MsLogging.LogLevel.Warning)
                  .AddSeq("http://localhost:5341/");
        });
        var stLogger = loggerFactory.CreateLogger<Program>();
        standartLogger = stLogger;
        standardLoggerAdapter = new StandardLoggerAdapter<Program>(stLogger);

        serialogLogger = new LoggerConfiguration()
            .WriteTo.Seq("http://localhost:5341/")
            .MinimumLevel.Warning()
            .CreateLogger()
            .ForContext<Program>();
    }

    public static void Main (string[] args)
    {
        BenchmarkRunner.Run(typeof(Program).Assembly);

        /*
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Seq("http://localhost:5341")
            .CreateLogger();

        var someClass = new MyClass
        {
            Integer = 101,
            String = "fdsd"
        };
        Log.Information("Hello, {@someClass}!", someClass);

        // Important to call at exit so that batched events are flushed.
        Log.CloseAndFlush();

        Console.ReadKey(true);
        */
    }
}
