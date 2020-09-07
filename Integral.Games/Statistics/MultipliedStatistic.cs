using Integral.Observers;

namespace Integral.Statistics
{
    public sealed class MultipliedStatistic : ValueObserver<int>, AggregateStatistic
    {
        private int zeroes;

        private int value = 1;

        public void Register(ObservedStatistic observedStatistic)
        {
            observedStatistic.OnChange += Change;
            if (observedStatistic.Value != 0)
            {
                SetValue(value * observedStatistic.Value);
            }
            else if (++zeroes == 1)
            {
                Value = 0;
            }
        }

        public void Unregister(ObservedStatistic observedStatistic)
        {
            observedStatistic.OnChange -= Change;
            if (observedStatistic.Value != 0)
            {
                SetValue(value / observedStatistic.Value);
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