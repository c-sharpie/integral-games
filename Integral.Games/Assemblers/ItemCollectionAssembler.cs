using Integral.Components;
using Integral.Items;

namespace Integral.Assemblers
{
    internal sealed class ItemCollectionAssembler<Key> : ItemComponentAssembler<Key>
        where Key : notnull
    {
        private readonly ItemCollectionComponent<Key> itemCollectionComponent;

        internal ItemCollectionAssembler(ItemCollectionComponent<Key> itemCollectionComponent) => this.itemCollectionComponent = itemCollectionComponent;

        public bool Add(Item<Key> item) => itemCollectionComponent.Add(item);

        public bool Remove(Item<Key> item) => itemCollectionComponent.Remove(item);
    }
}