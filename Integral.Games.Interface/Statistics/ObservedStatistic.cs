using Integral.Observers;

namespace Integral.Statistics
{
    public interface ObservedStatistic : ReadOnlyStatistic, Observer<float>
    {
    }
}