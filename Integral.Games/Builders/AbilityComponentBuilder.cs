using System;
using Integral.Assemblers;
using Integral.Components;

namespace Integral.Builders
{
    public sealed class AbilityComponentBuilder<Key> : ComponentBuilder<AbilityComponent<Key>, AbilityComponentAssembler<Key>>
        where Key : notnull
    {
        public override AbilityComponent<Key> Build(Action<AbilityComponentAssembler<Key>> action)
        {
            AbilityCollectionComponent<Key> abilityCollectionComponent = new AbilityCollectionComponent<Key>(Composition!);
            AbilityCollectionAssembler<Key> abilityCollectionAssembler = new AbilityCollectionAssembler<Key>(abilityCollectionComponent);
            action(abilityCollectionAssembler);
            return abilityCollectionComponent;
        }
    }
}