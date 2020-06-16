using Integral.Collections;
using Integral.Items;

namespace Integral.Components
{
    public interface ItemComponent<Key> : DirectCollection<Key, Item<Key>>, Component
        where Key : notnull
    {
    }
}