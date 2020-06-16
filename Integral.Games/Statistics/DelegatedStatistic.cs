using Integral.Publishers;
using Integral.Subscribers;

namespace Integral.Statistics
{
    internal sealed class DelegatedStatistic<Key> : ObservedStatistic<Key>, Subscriber<float>
        where Key : notnull
    {
        internal DelegatedStatistic(Key key, Publisher<float> publisher, float value = default) : base(key, value) => publisher.OnPublish += OnPublished;

        public void OnPublished(float value) => Value = value;
    }
}