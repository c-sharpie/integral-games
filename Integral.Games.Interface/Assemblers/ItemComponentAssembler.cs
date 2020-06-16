using Integral.Aggregates;
using Integral.Items;

namespace Integral.Assemblers
{
    public interface ItemComponentAssembler<in Key> : DirectAggregate<Item<Key>>
        where Key : notnull
    {
    }
}