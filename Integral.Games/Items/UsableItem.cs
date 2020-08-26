using Integral.Abilities;

namespace Integral.Items
{
    internal class UsableItem<ItemKey, AbilityKey> : InventoryItem<ItemKey>
        where ItemKey : notnull
        where AbilityKey : notnull
    {
        private readonly Ability<AbilityKey> ability;

        internal UsableItem(ItemKey itemKey, Ability<AbilityKey> ability) : base(itemKey) => this.ability = ability;

        public virtual void Use()
        {
        }
    }
}