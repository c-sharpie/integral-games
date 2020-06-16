using Integral.Components;
using Integral.Compositions;

namespace Integral.Items
{
    internal sealed class EquipableItem<ItemKey, AbilityKey, StatisticKey> : UsableItem<ItemKey, AbilityKey>
        where ItemKey : notnull
        where AbilityKey : notnull
        where StatisticKey : notnull
    {
        private readonly StatisticComponent<StatisticKey> statisticComponent;

        internal EquipableItem(ItemKey itemKey, AbilityComponent<AbilityKey> abilityComponent, StatisticComponent<StatisticKey> statisticComponent)
            : base(itemKey, abilityComponent) => this.statisticComponent = statisticComponent;

        public override void Use(Composition composition)
        {
        }
    }
}