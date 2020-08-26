using System;
using Integral.Assemblers;
using Integral.Formulae;
using Integral.Publishers;
using Integral.Statistics;

namespace Integral.Builders
{
    public sealed class StatisticBuilder<Key> : Builder<Statistic<Key>, StatisticAssembler<Key>>, StatisticAssembler<Key>
        where Key : notnull
    {
        public Statistic<Key> Build(Action<StatisticAssembler<Key>> action)
        {
            action(this);
            return null;
        }

        public void AddConstant(Key statistic, float value) => statisticCollection.Add(new ObservedStatistic<Key>(statistic, value));

        public void AddSummed(Key statistic, params Key[] sources) => statisticCollection.Add(new SummedStatistic<Key>(statistic, statisticCollection.Select(sources)));

        public void AddMultiplied(Key statistic, params Key[] sources) => statisticCollection.Add(new MultipliedStatistic<Key>(statistic, statisticCollection.Select(sources)));

        public void AddDelegated(Key statistic, Publisher<float> publisher) => statisticCollection.Add(new DelegatedStatistic<Key>(statistic, publisher));

        public void AddCalculated(Key statistic, Key source, StatisticFormula<float> formula) => statisticCollection.Add(new CalculatedStatistic<Key>(statistic, formula, statisticCollection[source]));
    }
}