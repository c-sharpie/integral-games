using Integral.Abilities;
using Integral.Statistics;

namespace Integral.Items
{
    internal sealed class EquipableItem<ItemKey, AbilityKey, StatisticKey> : UsableItem<ItemKey, AbilityKey>
        where ItemKey : notnull
        where AbilityKey : notnull
        where StatisticKey : notnull
    {
        private readonly Statistic<StatisticKey> statistic;

        internal EquipableItem(ItemKey itemKey, Ability<AbilityKey> ability, Statistic<StatisticKey> statistic)
            : base(itemKey, ability) => this.statistic = statistic;

        public override void Use()
        {
        }
    }
}