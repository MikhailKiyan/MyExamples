namespace MyConsoleApp.Extensions;

public static partial class EnumerableExtensions
{
    public static async Task ForEachInParallelAsync<TSource, TBasket>(
        this IEnumerable<TSource> source,
        int degreeOfParallelism,
        Func<TBasket> basketCreation,
        Func<TSource, TBasket, Task> process,
        Action<TBasket> basketDesposing,
        CancellationToken ct = default)
    {
        // check arguments






        throw new Exception();
    }
}
