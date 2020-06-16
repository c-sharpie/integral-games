using System.Collections.Generic;

namespace Integral.Statistics
{
    internal sealed class MultipliedStatistic<Key> : AggregateStatistic<Key>
        where Key : notnull
    {
        private int zeroes;

        private float value = 1.0f;

        internal MultipliedStatistic(Key key, IEnumerable<Statistic<Key>> statistics) : base(key, statistics)
        {
        }

        internal override void Subscribe(Statistic<Key> statistic)
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

        internal override void Unsubscribe(Statistic<Key> statistic)
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