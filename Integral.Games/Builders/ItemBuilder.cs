using System;
using Integral.Assemblers;
using Integral.Items;

namespace Integral.Builders
{
    public sealed class ItemBuilder<Key> : Builder<Item<Key>, ItemAssembler<Key>>, ItemAssembler<Key>
        where Key : notnull
    {
        public Item<Key> Build(Action<ItemAssembler<Key>> action)
        {
            action(this);


            //if (Statistic != null)
            //{
            //    return new EquipableItem<ItemKey, AbilityKey, StatisticKey>(Identity, Ability!, Statistic!);
            //}

            //if (Ability != null)
            //{
            //    return new UsableItem<ItemKey, AbilityKey>(Identity, Ability);
            //}

            //return new InventoryItem<ItemKey>(Identity);

            return null;
        }
    }
}