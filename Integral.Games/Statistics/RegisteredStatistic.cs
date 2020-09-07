using Integral.Observers;

namespace Integral.Statistics
{
    public abstract class RegisteredStatistic : ValueObserver<int>, AggregateStatistic
    {
        public void Register(ObservedStatistic observedStatistic)
        {
            observedStatistic.OnChange += Change;
            Register((Statistic)observedStatistic);
        }

        public void Unregister(ObservedStatistic observedStatistic)
        {
            observedStatistic.OnChange -= Change;
            Register((Statistic)observedStatistic);
        }

        public abstract void Register(Statistic statistic);

        public abstract void Unregister(Statistic statistic);

        protected abstract void Change(int previousValue, int currentValue);
    }
}
