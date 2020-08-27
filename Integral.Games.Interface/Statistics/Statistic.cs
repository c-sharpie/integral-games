using Integral.Observers;

namespace Integral.Statistics
{
    public interface Statistic : Observer<float>
    {
        float Value { get; }
    }
}