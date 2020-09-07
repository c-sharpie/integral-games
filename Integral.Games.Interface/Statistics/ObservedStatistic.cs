using Integral.Observers;

namespace Integral.Statistics
{
    public interface ObservedStatistic : Statistic, Observer<int>
    {
    }
}