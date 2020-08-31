using Integral.Formulae;

namespace Integral.Statistics
{
    public class CalculatedStatistic : ObservedStatistic
    {
        private readonly DeltaFormula<int> deltaFormula;

        public CalculatedStatistic(DeltaFormula<int> deltaFormula, Statistic statistic, int value = default) : base(deltaFormula.Evaluate(value, statistic.Value))
        {
            this.deltaFormula = deltaFormula;
            statistic.OnChange += Change;
        }

        private void Change(int previousValue, int currentValue) => Value = deltaFormula.Evaluate(previousValue, currentValue);
    }
}