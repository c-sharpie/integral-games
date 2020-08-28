using Integral.Observers;

namespace Integral.Statistics
{
    public class ObservedStatistic : ValueObserver<float>, Statistic
    {
        public ObservedStatistic(float value = default) : base(value)
        {
        }
    }
}