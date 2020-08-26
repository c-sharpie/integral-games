using Integral.Abstractions;
using Integral.Aggregates;

namespace Integral.Collections
{
    public interface PriorityCollection<Key, in Element> : PairedIncreasingAggregate<Key, Element>, IndirectDecreasingAggregate<Key>, Countable
        where Key : notnull
        where Element : notnull
    {
    }
}