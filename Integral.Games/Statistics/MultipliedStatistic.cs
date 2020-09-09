namespace Integral.Statistics
{
    public sealed class MultipliedStatistic : RegisteredStatistic
    {
        private int zeroes;

        private float value = 1;

        public override void Register(ReadOnlyStatistic statistic)
        {
            if (statistic.Value != 0)
            {
                SetValue(value * statistic.Value);
            }
            else if (++zeroes == 1)
            {
                Value = 0;
            }
        }

        public override void Unregister(ReadOnlyStatistic statistic)
        {
            if (statistic.Value != 0)
            {
                SetValue(value / statistic.Value);
            }
            else if (--zeroes == 0)
            {
                Value = value;
            }
        }

        protected override void Change(float previousValue, float currentValue)
        {
            if (currentValue != 0)
            {
                if (previousValue == 0)
                {
                    zeroes--;
                    SetValue(value * currentValue);
                }
                else
                {
                    SetValue(value / previousValue * currentValue);
                }
            }
            else
            {
                value /= previousValue;
                if (++zeroes == 1)
                {
                    Value = 0;
                }
            }
        }

        private void SetValue(float value)
        {
            this.value = value;
            if (zeroes == 0)
            {
                Value = value;
            }
        }
    }
}