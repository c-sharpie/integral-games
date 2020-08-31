using Integral.Observers;

namespace Integral.Statistics
{
    public interface Statistic : Observer<int>
    {
        int Value { get; }
    }
}