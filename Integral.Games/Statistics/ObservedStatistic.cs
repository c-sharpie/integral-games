using Integral.Observers;

namespace Integral.Statistics
{
    internal class ObservedStatistic<Key> : ValueObserver<float>, Statistic<Key>
        where Key : notnull
    {
        internal ObservedStatistic(Key key, float value = default) : base(value) => Identity = key;

        public Key Identity { get; }
    }
}