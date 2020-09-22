using Integral.Formulae;
using Integral.Observers;

namespace Integral.Statistics
{
    public class CalculatedStatistic : ValueObserver<float>, ObservedStatistic
    {
        private readonly DeltaFormula<float> deltaFormula;

        public CalculatedStatistic(DeltaFormula<float> deltaFormula, ObservedStatistic observedStatistic, int value = default) : base(deltaFormula.Evaluate(value, observedStatistic.Value))
        {
            this.deltaFormula = deltaFormula;
            observedStatistic.OnChange += Change;
        }

        private void Change(float previousValue, float currentValue) => Value = deltaFormula.Evaluate(previousValue, currentValue);
    }
}