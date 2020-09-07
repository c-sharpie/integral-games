using Integral.Observers;

namespace Integral.Statistics
{
    public sealed class SummedStatistic : ValueObserver<int>, AggregateStatistic
    {
        public void Register(ObservedStatistic observedStatistic)
        {
            observedStatistic.OnChange += Change;
            Value += observedStatistic.Value;
        }

        public void Unregister(ObservedStatistic observedStatistic)
        {
            observedStatistic.OnChange -= Change;
            Value -= observedStatistic.Value;
        }

        private void Change(int previousValue, int currentValue) => Value += currentValue - previousValue;
    }
}