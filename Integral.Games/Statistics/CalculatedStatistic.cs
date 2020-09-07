using Integral.Formulae;
using Integral.Observers;

namespace Integral.Statistics
{
    public sealed class CalculatedStatistic : ValueObserver<int>, ObservedStatistic
    {
        private readonly DeltaFormula<int> deltaFormula;

        public CalculatedStatistic(DeltaFormula<int> deltaFormula, ObservedStatistic observedStatistic, int value = default) : base(deltaFormula.Evaluate(value, observedStatistic.Value))
        {
            this.deltaFormula = deltaFormula;
            observedStatistic.OnChange += Change;
        }

        private void Change(int previousValue, int currentValue) => Value = deltaFormula.Evaluate(previousValue, currentValue);
    }
}