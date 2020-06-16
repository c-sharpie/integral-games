using Integral.Abilities;
using Integral.Components;

namespace Integral.Assemblers
{
    internal sealed class AbilityCollectionAssembler<Key> : AbilityComponentAssembler<Key>
        where Key : notnull
    {
        private readonly AbilityCollectionComponent<Key> abilityCollectionComponent;

        internal AbilityCollectionAssembler(AbilityCollectionComponent<Key> abilityCollectionComponent) => this.abilityCollectionComponent = abilityCollectionComponent;

        public bool Add(Ability<Key> ability) => abilityCollectionComponent.Add(ability);

        public bool Remove(Ability<Key> ability) => abilityCollectionComponent.Remove(ability);
    }
}