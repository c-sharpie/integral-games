using Integral.Components;
using Integral.Items;

namespace Integral.Factories
{
    public sealed class ItemFactory<ItemKey, AbilityKey, StatisticKey> : IdentifiableFactory<ItemKey, Item<ItemKey>>
        where ItemKey : notnull
        where AbilityKey : notnull
        where StatisticKey : notnull
    {
        public ItemFactory(ItemKey itemKey) : base(itemKey)
        {
        }

        public AbilityComponent<AbilityKey>? AbilityComponent { get; set; }

        public StatisticComponent<StatisticKey>? StatisticComponent { get; set; }

        public override Item<ItemKey> Create()
        {
            if (StatisticComponent != null)
            {
                return new EquipableItem<ItemKey, AbilityKey, StatisticKey>(Identity, AbilityComponent!, StatisticComponent!);
            }

            if (AbilityComponent != null)
            {
                return new UsableItem<ItemKey, AbilityKey>(Identity, AbilityComponent);
            }

            return new InventoryItem<ItemKey>(Identity);
        }
    }
}