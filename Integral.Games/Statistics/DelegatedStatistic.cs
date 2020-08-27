using Integral.Publishers;
using Integral.Subscribers;

namespace Integral.Statistics
{
    internal sealed class DelegatedStatistic : ObservedStatistic, Subscriber<float>
    {
        internal DelegatedStatistic(Publisher<float> publisher, float value = default) : base(value) => publisher.OnPublish += OnPublished;

        public void OnPublished(float value) => Value = value;
    }
}