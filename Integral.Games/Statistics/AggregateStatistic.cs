using System.Collections.Generic;

namespace Integral.Statistics
{
    internal abstract class AggregateStatistic<Key> : ObservedStatistic<Key>
        where Key : notnull
    {
        internal AggregateStatistic(Key key, IEnumerable<Statistic<Key>> statistics, float value = default) : base(key, value)
        {
            foreach (Statistic<Key> statistic in statistics)
            {
                Subscribe(statistic);
            }
        }

        internal abstract void Subscribe(Statistic<Key> statistic);

        internal abstract void Unsubscribe(Statistic<Key> statistic);
    }
}