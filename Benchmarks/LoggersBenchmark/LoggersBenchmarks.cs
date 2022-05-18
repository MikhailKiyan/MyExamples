namespace LoggersBenchmark;

using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;

[MemoryDiagnoser]
public class LoggersBenchmarks
{
    [Benchmark]
    public void StandartLogger_WithoutIf_Info()
    {
        Program.StandartLogger.LogInformation(
            "Logging: {someInteger} | {someString} | {@someClass}",
            Program.SomeInteger,
            Program.SomeString,
            Program.SomeClass);
    }

    [Benchmark]
    public void StandartLogger_WithoutIf_Warn()
    {
        Program.StandartLogger.LogWarning(
            "Logging: {someInteger} | {someString} | {@someClass}",
            Program.SomeInteger,
            Program.SomeString,
            Program.SomeClass);
    }

    [Benchmark]
    public void StandartLogger_WithIf_Info()
    {
        if (Program.StandartLogger.IsEnabled(LogLevel.Information))
            Program.StandartLogger.LogInformation(
                "Logging: {someInteger} | {someString} | {@someClass}",
                Program.SomeInteger,
                Program.SomeString,
                Program.SomeClass);
    }

    [Benchmark]
    public void StandartLogger_WithIf_Warn()
    {
        if (Program.StandartLogger.IsEnabled(LogLevel.Warning))
            Program.StandartLogger.LogWarning(
                "Logging: {someInteger} | {someString} | {@someClass}",
                Program.SomeInteger,
                Program.SomeString,
                Program.SomeClass);
    }

    /// <summary>
    /// Structured result is availlable for 'someClass'
    /// </summary>
    [Benchmark]
    public void StandartLogger_WithAdapter_Info()
    {

        Program.StandardLoggerAdapter.LogInformation(
            "Logging: {someInteger} | {someString} | {@someRecord}",
            Program.SomeInteger,
            Program.SomeString,
            Program.SomeClass);
    }

    /// <summary>
    /// Structured result is availlable for 'someClass'
    /// </summary>
    [Benchmark]
    public void StandartLogger_WithAdapter_Warn()
    {
        Program.StandardLoggerAdapter.LogWarning(
            "Logging: {someInteger} | {someString} | {@someClass}",
            Program.SomeInteger,
            Program.SomeString,
            Program.SomeClass);
    }

    /// <summary>
    /// Structured result is availlable for 'someClass'
    /// </summary>
    [Benchmark]
    public void StandartLogger_WithMessageDefinition_Info()
    {
        Program.StandartLogger.InformationWithDefinition(Program.SomeInteger, Program.SomeString, Program.SomeClass);
    }

    /// <summary>
    /// Structured result is availlable for 'someClass'
    /// </summary>
    [Benchmark]
    public void StandartLogger_WithMessageDefinition_Warn()
    {
        Program.StandartLogger.WarningWithDefinition(Program.SomeInteger, Program.SomeString, Program.SomeClass);
    }

    /// <summary>
    /// Structured result is not availlable for 'someClass'
    /// </summary>
    [Benchmark]
    public void StandartLogger_WithSourceGeneration_Info()
    {
        Program.StandartLogger.InformationWithSourceGeneration(Program.SomeInteger, Program.SomeString, Program.SomeClass);
    }

    /// <summary>
    /// Structured result is not availlable for 'someClass'
    /// </summary>
    [Benchmark]
    public void StandartLogger_WithSourceGeneration_Warn()
    {
        Program.StandartLogger.WarningWithSourceGeneration(Program.SomeInteger, Program.SomeString, Program.SomeClass);
    }

    /// <summary>
    /// Structured result is availlable for 'someClass'
    /// </summary>
    [Benchmark]
    public void Serilog_StringTemplete_Info()
    {
        Program.SerialogLogger.Information(
            "Logging: {someInteger} | {someString} | {@someRecord}",
                Program.SomeInteger,
                Program.SomeString,
                Program.SomeClass);
    }

    /// <summary>
    /// Structured result is availlable for 'someClass'
    /// </summary>
    [Benchmark]
    public void Serilog_StringTemplete_Warn()
    {
        Program.SerialogLogger.Warning(
            "Logging: {someInteger} | {someString} | {@someClass}",
                Program.SomeInteger,
                Program.SomeString,
                Program.SomeClass);
    }

    /// <summary>
    /// Structured result is not availlable
    /// </summary>
    [Benchmark]
    public void StandartLogger_InterpoletedString_Info()
    {
        Program.StandartLogger.LogInformation(
            $"Logging: {Program.SomeInteger} | {Program.SomeString} | {Program.SomeClass}");
    }

    /// <summary>
    /// Structured result is not availlable
    /// </summary>
    [Benchmark]
    public void StandartLogger_InterpoletedString_Warn()
    {
        Program.StandartLogger.LogWarning(
            $"Logging: {Program.SomeInteger} | {Program.SomeString} | {Program.SomeClass}");
    }

    /// <summary>
    /// Structured result is availlable
    /// </summary>
    [Benchmark]
    public void Serilog_InterpoletedStringHandler_Info()
    {
        var someInteger = Program.SomeInteger;
        var someString = Program.SomeString;
        var someClass = Program.SomeClass;
        Program.SerialogLogger.InformationWithInterpoletedString(
            $"Logging: {someInteger} | {someString} | {@someClass}");
    }

    /// <summary>
    /// Structured result is availlable
    /// </summary>
    [Benchmark]
    public void Serilog_InterpoletedStringHandler_Warn()
    {
        var someInteger = Program.SomeInteger;
        var someString = Program.SomeString;
        var someClass = Program.SomeClass;
        Program.SerialogLogger.WarningWithInterpoletedString(
            $"Logging: {someInteger} | {someString} | {@someClass}");
    }
}