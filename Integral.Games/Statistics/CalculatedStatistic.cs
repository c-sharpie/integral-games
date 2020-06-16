using Integral.Formulae;

namespace Integral.Statistics
{
    internal class CalculatedStatistic<Key> : ObservedStatistic<Key>
        where Key : notnull
    {
        private readonly StatisticFormula<float> statisticFormula;

        internal CalculatedStatistic(Key key, StatisticFormula<float> statisticFormula, Statistic<Key> statistic, float value = default)
            : base(key, statisticFormula.Evaluate(value, statistic.Value))
        {
            this.statisticFormula = statisticFormula;
            statistic.OnChange += Change;
        }

        private void Change(float previousValue, float currentValue) => Value = statisticFormula.Evaluate(previousValue, currentValue);
    }
}