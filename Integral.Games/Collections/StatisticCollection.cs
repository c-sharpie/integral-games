using Adonai.Enumerations;
using Integral.Collections;
using Integral.Functions;
using Integral.Statistics;

namespace Adonai.Collections
{
    public class StatisticCollection : EnumeratedCollection<StatisticName, ObservedStatistic>
    {
        protected KeyedCollection<StatisticSource, StatisticSourceCollection> Sources { get; } = new EnumeratedCollection<StatisticSource, StatisticSourceCollection>();

        protected KeyedCollection<StatisticName, AggregateStatistic> Modifiers { get; } = new IndexedCollection<StatisticName, AggregateStatistic>();

        protected override ObservedStatistic Create(StatisticName statisticName)
        {
            ModifiedStatistic modifiedStatistic = new ModifiedStatistic();
            Modifiers.Add(statisticName, modifiedStatistic.Modifiers);

            AggregateStatistic aggregateStatistic = modifiedStatistic.Values;
            foreach (StatisticSource statisticSource in EnumFunction.GetValues<StatisticSource>())
            {
                aggregateStatistic.Register(Sources[statisticSource][statisticName]);
            }

            return modifiedStatistic;
        }
    }
}
