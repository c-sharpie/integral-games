using Integral.Components;
using Integral.Compositions;

namespace Integral.Items
{
    internal class UsableItem<ItemKey, AbilityKey> : InventoryItem<ItemKey>
        where ItemKey : notnull
        where AbilityKey : notnull
    {
        private readonly AbilityComponent<AbilityKey> abilityComponent;

        internal UsableItem(ItemKey itemKey, AbilityComponent<AbilityKey> abilityComponent) : base(itemKey) => this.abilityComponent = abilityComponent;

        public virtual void Use(Composition composition)
        {
        }
    }
}