using System;
using Integral.Assemblers;
using Integral.Components;

namespace Integral.Builders
{
    public sealed class ItemComponentBuilder<Key> : ComponentBuilder<ItemComponent<Key>, ItemComponentAssembler<Key>>
        where Key : notnull
    {
        public override ItemComponent<Key> Build(Action<ItemComponentAssembler<Key>> action)
        {
            ItemCollectionComponent<Key> itemCollectionComponent = new ItemCollectionComponent<Key>(Composition!);
            ItemCollectionAssembler<Key> itemCollectionAssembler = new ItemCollectionAssembler<Key>(itemCollectionComponent);
            action(itemCollectionAssembler);
            return itemCollectionComponent;
        }
    }
}