using Integral.Compositions;
using Integral.Items;

namespace Integral.Components
{
    internal sealed class ItemCollectionComponent<Key> : CollectionComponent<Key, Item<Key>>, ItemComponent<Key>
        where Key : notnull
    {
        internal ItemCollectionComponent(Composition composition) : base(composition)
        {
        }
    }
}