using Integral.Publishers;
using Integral.Subscribers;

namespace Integral.Statistics
{
    public sealed class DelegatedStatistic : ObservedStatistic, Subscriber<float>
    {
        public DelegatedStatistic(Publisher<float> publisher, float value = default) : base(value) => publisher.OnPublish += OnPublished;

        public void OnPublished(float value) => Value = value;
    }
}