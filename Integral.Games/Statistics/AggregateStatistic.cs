using System.Collections.Generic;

namespace Integral.Statistics
{
    internal abstract class AggregateStatistic : ObservedStatistic
    {
        internal AggregateStatistic(IEnumerable<Statistic> statistics, float value = default) : base(value)
        {
            foreach (Statistic statistic in statistics)
            {
                Subscribe(statistic);
            }
        }

        internal abstract void Subscribe(Statistic statistic);

        internal abstract void Unsubscribe(Statistic statistic);
    }
}