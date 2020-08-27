using System.Collections.Generic;

namespace Integral.Statistics
{
    internal sealed class MultipliedStatistic : AggregateStatistic
    {
        private int zeroes;

        private float value = 1.0f;

        internal MultipliedStatistic(IEnumerable<Statistic> statistics) : base(statistics)
        {
        }

        internal override void Subscribe(Statistic statistic)
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

        internal override void Unsubscribe(Statistic statistic)
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

        private void Change(float previousValue, float currentValue)
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