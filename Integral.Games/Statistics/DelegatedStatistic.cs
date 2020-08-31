using Integral.Publishers;
using Integral.Subscribers;

namespace Integral.Statistics
{
    public sealed class DelegatedStatistic : ObservedStatistic, Subscriber<int>
    {
        public DelegatedStatistic(Publisher<int> publisher, int value = default) : base(value) => publisher.OnPublish += OnPublished;

        public void OnPublished(int value) => Value = value;
    }
}