using System.Collections.Generic;

namespace Integral.Statistics
{
    internal sealed class SummedStatistic<Key> : AggregateStatistic<Key>
        where Key : notnull
    {
        internal SummedStatistic(Key key, IEnumerable<Statistic<Key>> statistics) : base(key, statistics)
        {
        }

        internal override void Subscribe(Statistic<Key> statistic)
        {
            statistic.OnChange += Change;
            Value += statistic.Value;
        }

        internal override void Unsubscribe(Statistic<Key> statistic)
        {
            statistic.OnChange -= Change;
            Value -= statistic.Value;
        }

        private void Change(float previousValue, float currentValue) => Value += currentValue - previousValue;
    }
}