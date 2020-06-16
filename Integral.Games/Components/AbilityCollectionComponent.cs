using Integral.Abilities;
using Integral.Compositions;

namespace Integral.Components
{
    internal sealed class AbilityCollectionComponent<Key> : CollectionComponent<Key, Ability<Key>>, AbilityComponent<Key>
        where Key : notnull
    {
        internal AbilityCollectionComponent(Composition composition) : base(composition)
        {
        }

        public override bool Add(Ability<Key> ability)
        {
            ability.Register(Composition);
            return base.Add(ability);
        }

        public override bool Remove(Ability<Key> ability)
        {
            ability.Unregister(Composition);
            return base.Remove(ability);
        }
    }
}