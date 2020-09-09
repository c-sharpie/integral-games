using System;

namespace Integral.Statistics
{
    public sealed class ClampedStatistic : TransientStatistic, Statistic
    {
        private readonly ReadOnlyStatistic value, min, max;

        public ClampedStatistic(ObservedStatistic value, ObservedStatistic min, ObservedStatistic max)
        {
            this.value = value;
            this.min = min;
            this.max = max;

            value.OnChange += ChangeValue;
            min.OnChange += ChangeMin;
            max.OnChange += ChangeMax;
        }

        private void ChangeValue(float previousValue, float currentValue) => Value = Math.Clamp(currentValue, min.Value, max.Value);

        private void ChangeMin(float previousValue, float currentValue) => Value = Math.Max(currentValue, value.Value);

        private void ChangeMax(float previousValue, float currentValue) => Value = Math.Min(currentValue, value.Value);
    }
}
