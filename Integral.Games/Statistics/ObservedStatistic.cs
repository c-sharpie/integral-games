using Integral.Observers;

namespace Integral.Statistics
{
    public class ObservedStatistic : ValueObserver<int>, Statistic
    {
        public ObservedStatistic(int value = default) : base(value)
        {
        }
    }
}