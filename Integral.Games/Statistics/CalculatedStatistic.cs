using Integral.Formulae;

namespace Integral.Statistics
{
    public class CalculatedStatistic : ObservedStatistic
    {
        private readonly DeltaFormula<float> deltaFormula;

        public CalculatedStatistic(DeltaFormula<float> deltaFormula, Statistic statistic, float value = default) : base(deltaFormula.Evaluate(value, statistic.Value))
        {
            this.deltaFormula = deltaFormula;
            statistic.OnChange += Change;
        }

        private void Change(float previousValue, float currentValue) => Value = deltaFormula.Evaluate(previousValue, currentValue);
    }
}