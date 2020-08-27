using Integral.Formulae;

namespace Integral.Statistics
{
    internal class CalculatedStatistic : ObservedStatistic
    {
        private readonly DeltaFormula<float> deltaFormula;

        internal CalculatedStatistic(DeltaFormula<float> deltaFormula, Statistic statistic, float value = default) : base(deltaFormula.Evaluate(value, statistic.Value))
        {
            this.deltaFormula = deltaFormula;
            statistic.OnChange += Change;
        }

        private void Change(float previousValue, float currentValue) => Value = deltaFormula.Evaluate(previousValue, currentValue);
    }
}