using Integral.Statistics;

namespace Integral.Collections
{
    public class StatisticCollection<T, U> : IndexedCollection<T, U>
        where T : notnull
        where U : ObservedStatistic
    {
    }
}
