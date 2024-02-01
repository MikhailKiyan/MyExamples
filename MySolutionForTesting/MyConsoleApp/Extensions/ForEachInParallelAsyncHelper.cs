namespace MyConsoleApp.Extensions;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public static partial class EnumerableExtensions
{
    private class ForEachInParallelAsyncHelper<TSource, TBasket>
    {
        private readonly IEnumerator<TSource> enumerator;
        private readonly int degreeOfParallelism;
        private readonly Func<TBasket> basketCreation;
        private readonly Action<TBasket> basketDesposing;
        private readonly CancellationToken ct;
        private readonly object sync;
        private int started;

        public ForEachInParallelAsyncHelper(
                IEnumerable<TSource> source,
                int degreeOfParallelism,
                Func<TBasket> basketCreation,
                Action<TBasket> basketDesposing,
                CancellationToken ct)
        {
            this.enumerator = source.GetEnumerator();
            this.degreeOfParallelism = degreeOfParallelism;
            this.basketCreation = basketCreation;
            this.basketDesposing = basketDesposing;
            this.ct = ct;
            this.sync = new object();
        }

        public async Task DoAsync(Func<TSource?, TBasket?, Task> process)
        {
            CheckIfAlreadyStarted();
            var baskets = Enumerable.Range(0, degreeOfParallelism).ToArray();
            var tasks = baskets.Select(async _ =>
            {
                var basketConfiguration = basketCreation();
                // TODO: don't wait to start the next task
                // don't attach the created task to the current task.
                // await Task.Run(() => InnerProcess(basketConfiguration, process).ConfigureAwait(false));
                await InnerProcess(basketConfiguration, process).ConfigureAwait(false);
                if (basketDesposing is not null && basketConfiguration is not null) basketDesposing(basketConfiguration);
            }).ToArray();
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        private async Task InnerProcess(
                TBasket basketConfiguration,
                Func<TSource?, TBasket?, Task> process)
        {
            while (true)
            {
                var (next, item) = TryGetNext();
                if (!next) break;
                await process(item, basketConfiguration).ConfigureAwait(false);
            }
        }

        private (bool Next, TSource? Item) TryGetNext()
        {
            lock (sync)
            {
                var next = this.enumerator.MoveNext();
                var item = next ? this.enumerator.Current : default;
                return (next, item);
            }
        }

        private void CheckIfAlreadyStarted()
        {
            var originalValue = Interlocked.CompareExchange(ref this.started, 1, 0);
            if (originalValue != 0) throw new ApplicationException("Helper can be used only one time");
        }
    }
}
