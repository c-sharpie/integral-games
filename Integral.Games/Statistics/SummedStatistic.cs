﻿namespace Integral.Statistics
{
    public sealed class SummedStatistic : RegisteredStatistic
    {
        public override void Register(ReadOnlyStatistic statistic) => Value += statistic.Value;

        public override void Unregister(ReadOnlyStatistic statistic) => Value -= statistic.Value;

        protected override void Change(float previousValue, float currentValue) => Value += currentValue - previousValue;
    }
}