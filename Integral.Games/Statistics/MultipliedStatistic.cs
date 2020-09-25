﻿namespace Integral.Statistics
{
    public class MultipliedStatistic : RegisteredStatistic
    {
        public override void Register(ReadOnlyStatistic statistic) => Change(0, statistic.Value);

        public override void Unregister(ReadOnlyStatistic statistic) => Change(statistic.Value, 0);

        protected override void Change(float previousValue, float currentValue)
        {
            if (currentValue != 0)
            {
                if (previousValue == 0)
                {
                    Value = Value == 0 ? currentValue : Value * currentValue;
                }
                else
                {
                    Value = Value / previousValue * currentValue;
                }
            }
            else if (previousValue != 0)
            {
                Value /= previousValue;
            }
        }
    }
}