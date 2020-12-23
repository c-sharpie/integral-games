using Adonai.Enumerations;
using Integral.Collections;
using Integral.Statistics;

namespace Adonai.Collections
{
    public class StatisticSourceCollection : EnumeratedCollection<StatisticName, MultipliedStatistic>
    {
        public KeyedCollection<StatisticName, ModifiedStatistic> Sources { get; } = new EnumeratedCollection<StatisticName, ModifiedStatistic>();

        public AggregateStatistic Modifiers { get; } = new SummedStatistic();

        protected override MultipliedStatistic Create(StatisticName statisticName)
        {
            MultipliedStatistic multipliedStatistic = new MultipliedStatistic();
            multipliedStatistic.Register(Sources[statisticName]);
            multipliedStatistic.Register(Modifiers);
            return multipliedStatistic;
        }
    }
}
