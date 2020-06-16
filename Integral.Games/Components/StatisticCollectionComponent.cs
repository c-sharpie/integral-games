using Integral.Compositions;
using Integral.Extensions;
using Integral.Statistics;

namespace Integral.Components
{
    internal sealed class StatisticCollectionComponent<Key> : CollectionComponent<Key, Statistic<Key>>, StatisticComponent<Key>
        where Key : notnull
    {
        internal StatisticCollectionComponent(Composition composition) : base(composition)
        {
        }

        public override bool Add(Statistic<Key> statistic)
        {
            if (this.CastedPeek(statistic.Identity, out AggregateStatistic<Key> aggregateStatistic))
            {
                aggregateStatistic.Subscribe(statistic);
                return true;
            }

            return base.Add(statistic);
        }

        public override bool Remove(Statistic<Key> statistic)
        {
            if (this.CastedPeek(statistic.Identity, out AggregateStatistic<Key> aggregateStatistic))
            {
                aggregateStatistic.Unsubscribe(statistic);
                return true;
            }

            return base.Remove(statistic);
        }
    }
}