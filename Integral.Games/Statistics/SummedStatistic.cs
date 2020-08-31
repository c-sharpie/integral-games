using System.Collections.Generic;

namespace Integral.Statistics
{
    public sealed class SummedStatistic : AggregateStatistic
    {
        public SummedStatistic()
        {
        }

        public SummedStatistic(IEnumerable<Statistic> statistics) : base(statistics)
        {
        }

        public override void Register(Statistic statistic)
        {
            statistic.OnChange += Change;
            Value += statistic.Value;
        }

        public override void Unregister(Statistic statistic)
        {
            statistic.OnChange -= Change;
            Value -= statistic.Value;
        }

        private void Change(float previousValue, float currentValue) => Value += currentValue - previousValue;
    }
}