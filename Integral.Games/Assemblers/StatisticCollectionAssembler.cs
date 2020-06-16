using Integral.Components;
using Integral.Extensions;
using Integral.Formulae;
using Integral.Publishers;
using Integral.Statistics;

namespace Integral.Assemblers
{
    internal sealed class StatisticCollectionAssembler<Key> : StatisticComponentAssembler<Key>
        where Key : notnull
    {
        private readonly StatisticCollectionComponent<Key> statisticCollectionComponent;

        internal StatisticCollectionAssembler(StatisticCollectionComponent<Key> statisticCollectionComponent) => this.statisticCollectionComponent = statisticCollectionComponent;

        public void AddConstant(Key statistic, float value) => statisticCollectionComponent.Add(new ObservedStatistic<Key>(statistic, value));

        public void AddSummed(Key statistic, params Key[] sources) => statisticCollectionComponent.Add(new SummedStatistic<Key>(statistic, statisticCollectionComponent.Select(sources)));

        public void AddMultiplied(Key statistic, params Key[] sources) => statisticCollectionComponent.Add(new MultipliedStatistic<Key>(statistic, statisticCollectionComponent.Select(sources)));

        public void AddDelegated(Key statistic, Publisher<float> publisher) => statisticCollectionComponent.Add(new DelegatedStatistic<Key>(statistic, publisher));

        public void AddCalculated(Key statistic, Key source, StatisticFormula<float> formula) => statisticCollectionComponent.Add(new CalculatedStatistic<Key>(statistic, formula, statisticCollectionComponent[source]));
    }
}