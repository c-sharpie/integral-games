using System;

namespace Integral.Statistics
{
    public sealed class ClampedStatistic : TransientStatistic
    {
        private readonly ReadOnlyStatistic min, max, main;

        public ClampedStatistic(ObservedStatistic min, ObservedStatistic max, ObservedStatistic main)
            : this((ReadOnlyStatistic)min, max, main) => min.OnChange += ChangeMin;

        public ClampedStatistic(ReadOnlyStatistic min, ObservedStatistic max, ObservedStatistic main)
            : this(min, (ReadOnlyStatistic)max, main) => max.OnChange += ChangeMax;

        public ClampedStatistic(ReadOnlyStatistic min, ReadOnlyStatistic max, ObservedStatistic main)
            : this(min, max, (ReadOnlyStatistic)main) => main.OnChange += ChangeValue;

        public ClampedStatistic(ReadOnlyStatistic min, ReadOnlyStatistic max, ReadOnlyStatistic main)
        {
            this.min = min;
            this.max = max;
            this.main = main;
        }

        private void ChangeMin(float previousValue, float currentValue) => Value = Math.Max(currentValue, main.Value);

        private void ChangeMax(float previousValue, float currentValue) => Value = Math.Min(currentValue, main.Value);

        private void ChangeValue(float previousValue, float currentValue) => Value = Math.Clamp(currentValue, min.Value, max.Value);
    }
}
