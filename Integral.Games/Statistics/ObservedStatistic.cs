using Integral.Observers;

namespace Integral.Statistics
{
    internal class ObservedStatistic : ValueObserver<float>, Statistic
    {
        internal ObservedStatistic(float value = default) : base(value)
        {
        }
    }
}