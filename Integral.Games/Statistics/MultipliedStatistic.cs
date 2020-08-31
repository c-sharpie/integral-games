using System.Collections.Generic;

namespace Integral.Statistics
{
    public sealed class MultipliedStatistic : AggregateStatistic
    {
        private int zeroes;

        private int value = 1;

        public MultipliedStatistic()
        {
        }

        public MultipliedStatistic(IEnumerable<Statistic> statistics) : base(statistics)
        {
        }

        public override void Register(Statistic statistic)
        {
            statistic.OnChange += Change;
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
            statistic.OnChange -= Change;
            if (statistic.Value != 0)
            {
                SetValue(value / statistic.Value);
            }
            else if (--zeroes == 0)
            {
                Value = value;
            }
        }

        private void Change(int previousValue, int currentValue)
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