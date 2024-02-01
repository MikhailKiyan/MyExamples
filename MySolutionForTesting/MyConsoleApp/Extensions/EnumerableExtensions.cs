namespace MyConsoleApp.Extensions;

public static partial class EnumerableExtensions
{
    public static async Task ForEachInParallelAsync<TSource, TBasket>(
        this IEnumerable<TSource> source,
        int degreeOfParallelism,
        Func<TBasket?> basketCreation,
        Func<TSource?, TBasket?, Task> process,
        Action<TBasket?> basketDesposing,
        CancellationToken ct = default)
    {
        // TODO: check arguments


        var helper = new ForEachInParallelAsyncHelper<TSource, TBasket>(source, degreeOfParallelism, basketCreation, basketDesposing, ct);
        await helper.DoAsync(process).ConfigureAwait(false);
    }
}
