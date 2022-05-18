using System.Text;
using BenchmarkDotNet.Attributes;

namespace MyExaples.Benchmark;

[MemoryDiagnoser]
public class MemoryBenchmarkDemo {
    int NumberOfItems = 100_000;

    /// <summary>
    /// Performence test of concatination using StringBuilder
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public string ConcatStringsUsingStringBuilder() {
        var sb = new StringBuilder();
        for (int i = 0; i < NumberOfItems; i++) {
            sb.Append("Hello World!" + i);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Performence test of concatination using List of String
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public string ConcatStringsUsingGenericList() {
        var list = new List<string>(NumberOfItems);
        for (int i = 0; i < NumberOfItems; i++) {
            list.Add("Hello World!" + i);
        }
        return list.ToString() ?? "";
    }
}