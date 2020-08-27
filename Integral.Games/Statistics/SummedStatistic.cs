using System.Collections.Generic;

namespace Integral.Statistics
{
    internal sealed class SummedStatistic : AggregateStatistic
    {
        internal SummedStatistic(IEnumerable<Statistic> statistics) : base(statistics)
        {
        }

        internal override void Subscribe(Statistic statistic)
        {
            statistic.OnChange += Change;
            Value += statistic.Value;
        }

        internal override void Unsubscribe(Statistic statistic)
        {
            statistic.OnChange -= Change;
            Value -= statistic.Value;
        }

        private void Change(float previousValue, float currentValue) => Value += currentValue - previousValue;
    }
}