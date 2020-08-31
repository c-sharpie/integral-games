using System.Collections.Generic;
using Integral.Registries;

namespace Integral.Statistics
{
    public abstract class AggregateStatistic : ObservedStatistic, Registry<Statistic>
    {
        public AggregateStatistic()
        {
        }

        public AggregateStatistic(IEnumerable<Statistic> statistics, float value = default) : base(value)
        {
            foreach (Statistic statistic in statistics)
            {
                Register(statistic);
            }
        }

        public abstract void Register(Statistic statistic);

        public abstract void Unregister(Statistic statistic);
    }
}