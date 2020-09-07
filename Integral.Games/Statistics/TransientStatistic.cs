using Integral.Observers;

namespace Integral.Statistics
{
    public class TransientStatistic : ValueObserver<int>, ObservedStatistic, Statistic
    {
        public TransientStatistic(int value = default) : base(value)
        {
        }
    }
}