using System;

namespace Integral.Statistics
{
    public abstract class AbstractStatistic<T> : ObservedStatistic
        where T : ObservedStatistic, new()
    {
        protected T Statistic { get; } = new T();

        public float Value => Statistic.Value;

        public event Action<float, float> OnChange
        {
            add => Statistic.OnChange += value;
            remove => Statistic.OnChange -= value;
        }
    }
}
