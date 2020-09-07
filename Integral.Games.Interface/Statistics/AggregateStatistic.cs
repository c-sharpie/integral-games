using Integral.Registries;

namespace Integral.Statistics
{
    public interface AggregateStatistic : ObservedStatistic, Registry<ObservedStatistic>, Registry<Statistic>
    {
    }
}