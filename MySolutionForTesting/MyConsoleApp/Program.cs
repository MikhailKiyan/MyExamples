namespace MyConsoleApp;

using MyConsoleApp.Extensions;

using System.Diagnostics;

internal class Program
{
    static async Task<int> Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var ct = CancellationToken.None;
        var testSet = Enumerable.Range(0, 1000).ToArray();

        await testSet.ForEachInParallelAsync(
            100,
            () => new { Client = new HttpClient() },
            async (item, basket) =>
            {
                var threadId = Thread.CurrentThread.ManagedThreadId;
                var envThreadId = Environment.CurrentManagedThreadId;
                var taskId = Task.CurrentId;
                await Console.Out.WriteLineAsync($"Item is {item}, thread is {threadId}/{envThreadId}, task is {taskId}: starting")
                    .ConfigureAwait(false);
                var watcher = Stopwatch.StartNew();
                var response = await basket.Client.GetAsync("https://google.com")
                    .ConfigureAwait(false);
                watcher.Stop();
                threadId = Thread.CurrentThread.ManagedThreadId;
                envThreadId = Environment.CurrentManagedThreadId;
                taskId = Task.CurrentId;
                await Console.Out.WriteLineAsync($"Item is {item}, thread is {threadId}/{envThreadId}, task is {taskId}: finished, took {watcher.Elapsed}")
                    .ConfigureAwait(false);
            },
            basket => basket.Client.Dispose(),
            ct);

        return 0;
    }
}
