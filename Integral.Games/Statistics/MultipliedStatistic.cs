namespace Integral.Statistics
{
    public sealed class MultipliedStatistic : RegisteredStatistic
    {
        private int zeroes;

        private int value = 1;

        public override void Register(Statistic statistic)
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

        public override void Unregister(Statistic statistic)
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

        protected override void Change(int previousValue, int currentValue)
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

        private void SetValue(int value)
        {
            this.value = value;
            if (zeroes == 0)
            {
                Value = value;
            }
        }
    }
}