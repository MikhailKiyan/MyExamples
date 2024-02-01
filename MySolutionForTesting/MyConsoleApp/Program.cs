using MyConsoleApp.Extensions;
using System.Diagnostics;

namespace MyConsoleApp;

internal class Program
{
    static async Task<int> Main(string[] args)
    {
        await Console.Out.WriteLineAsync("Started").ConfigureAwait(false);

        var ct = CancellationToken.None;
        var testSet = Enumerable.Range(0, 1000).ToArray();

        await testSet.ForEachInParallelAsync(
            100,
            () => new { Client = new HttpClient() },
            async (item, basket) =>
            {
                var threadId = Thread.CurrentThread.ManagedThreadId;
                var taskId = Task.CurrentId;
                await Console.Out.WriteLineAsync($"Item is {item}, thread is {threadId}, task is {taskId}: starting")
                    .ConfigureAwait(false);
                var watcher = Stopwatch.StartNew();
                var response = await basket.Client.GetAsync("http://localhost")
                    .ConfigureAwait(false);
                watcher.Stop();
                threadId = Thread.CurrentThread.ManagedThreadId;
                taskId = Task.CurrentId;
                await Console.Out.WriteLineAsync($"Item is {item}, thread is {threadId}, task is {taskId}: finished, took {watcher.Elapsed}")
                    .ConfigureAwait(false);
            },
            basket => basket.Client.Dispose(),
            ct).ConfigureAwait(false);

        await Console.Out.WriteLineAsync("Finished").ConfigureAwait(false);
        return 0;
    }
}
