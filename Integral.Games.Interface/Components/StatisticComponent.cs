using Integral.Collections;
using Integral.Statistics;

namespace Integral.Components
{
    public interface StatisticComponent<Key> : DirectCollection<Key, Statistic<Key>>, Component
        where Key : notnull
    {
    }
}