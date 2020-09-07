using Integral.Observers;

namespace Integral.Statistics
{
    public abstract class RegisteredStatistic : ValueObserver<int>, AggregateStatistic
    {
        public void Register(ObservedStatistic observedStatistic)
        {
            observedStatistic.OnChange += Change;
            Register((ReadOnlyStatistic)observedStatistic);
        }

        public void Unregister(ObservedStatistic observedStatistic)
        {
            observedStatistic.OnChange -= Change;
            Register((ReadOnlyStatistic)observedStatistic);
        }

        public abstract void Register(ReadOnlyStatistic statistic);

        public abstract void Unregister(ReadOnlyStatistic statistic);

        protected abstract void Change(int previousValue, int currentValue);
    }
}
