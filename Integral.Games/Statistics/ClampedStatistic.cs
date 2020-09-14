using System;

namespace Integral.Statistics
{
    public sealed class ClampedStatistic : TransientStatistic
    {
        private readonly ReadOnlyStatistic min, max;

        public ClampedStatistic(ObservedStatistic min, ObservedStatistic max)
        {
            this.min = min;
            this.max = max;

            min.OnChange += ChangeMin;
            max.OnChange += ChangeMax;
            OnChange += ChangeValue;
        }

        private void ChangeMin(float previousValue, float currentValue) => Value = Math.Max(currentValue, Value);

        private void ChangeMax(float previousValue, float currentValue) => Value = Math.Min(currentValue, Value);

        private void ChangeValue(float previousValue, float currentValue) => Value = Math.Clamp(currentValue, min.Value, max.Value);
    }
}
