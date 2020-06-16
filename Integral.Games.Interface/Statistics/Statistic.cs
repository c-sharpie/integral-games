using Integral.Abstractions;
using Integral.Observers;

namespace Integral.Statistics
{
    public interface Statistic<out Key> : Identifiable<Key>, Observer<float>
        where Key : notnull
    {
        float Value { get; }
    }
}