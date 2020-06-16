using System;
using Integral.Abilities;
using Integral.Aggregates;
using Integral.Compositions;
using Integral.Conditions;
using Integral.Consumers;
using Integral.Enumerations;
using Integral.Registries;

namespace Integral.Factories
{
    public sealed class AbilityFactory<Key> : IdentifiableFactory<Key, Ability<Key>>
        where Key : notnull
    {
        public AbilityFactory(Key key) : base(key)
        {
        }

        public AbilityType AbilityType { get; set; }

        public Consumer<Composition>? Consumer { get; set; }

        public Registry<Composition, DirectAggregate<Condition>>? Registry { get; set; }

        public override Ability<Key> Create()
        {
            return AbilityType switch
            {
                AbilityType.Active => new ActiveAbility<Key>(Identity, Consumer!, Registry!),
                AbilityType.Passive => new PassiveAbility<Key>(Identity, Consumer!, Registry!),
                _ => throw new NotImplementedException()
            };
        }
    }
}