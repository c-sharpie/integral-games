using System;
using Integral.Observers;

namespace Integral.Statistics
{
    public sealed class ClampedStatistic : ValueObserver<int>, ObservedStatistic
    {
        private readonly ObservedStatistic min, max, main;

        public ClampedStatistic(ObservedStatistic min, ObservedStatistic max, ObservedStatistic main)
        {
            this.min = min;
            this.max = max;
            this.main = main;

            min.OnChange += ChangeMin;
            max.OnChange += ChangeMax;
            main.OnChange += ChangeMain;
        }

        private void ChangeMin(int previousValue, int currentValue) => Value = Math.Max(currentValue, main.Value);

        private void ChangeMax(int previousValue, int currentValue) => Value = Math.Min(currentValue, main.Value);

        private void ChangeMain(int previousValue, int currentValue) => Value = Math.Clamp(currentValue, min.Value, max.Value);
    }
}
