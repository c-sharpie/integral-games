using Integral.Collections;
using Integral.Statistics;

namespace Adonai.Collections
{
    public class StatisticSourceCollection<T, U, V> : IndexedCollection<T, StatisticCollection<U, V>>
        where T : notnull
        where U : notnull
        where V : ObservedStatistic
    {
    }
}
