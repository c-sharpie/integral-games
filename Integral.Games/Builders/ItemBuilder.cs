using System;
using Integral.Assemblers;
using Integral.Items;

namespace Integral.Builders
{
    public sealed class ItemBuilder : Builder<Item, ItemAssembler>
    {
        public Item Build(Action<ItemAssembler> itemAssemblerAction)
        {
            Assembler assembler = new Assembler();
            itemAssemblerAction(assembler);
            return assembler.Assemble();
        }

        private sealed class Assembler : ItemAssembler
        {
            internal Item Assemble()
            {
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
}