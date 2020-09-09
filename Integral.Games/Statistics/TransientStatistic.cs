using Integral.Observers;

namespace Integral.Statistics
{
    public class TransientStatistic : ValueObserver<float>, ObservedStatistic, Statistic
    {
        public TransientStatistic(float value = default) : base(value)
        {
        }
    }
}