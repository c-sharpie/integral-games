using Integral.Abilities;

namespace Integral.Items
{
    internal class UsableItem : InventoryItem
    {
        private readonly Ability ability;

        public UsableItem(Ability ability) => this.ability = ability;

        public virtual void Use()
        {
        }
    }
}