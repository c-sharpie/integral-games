using System;
using Integral.Abilities;
using Integral.Assemblers;

namespace Integral.Builders
{
    public sealed class AbilityBuilder<Key> : Builder<Ability<Key>, AbilityAssembler<Key>>, AbilityAssembler<Key>
        where Key : notnull
    {
        public Ability<Key> Build(Action<AbilityAssembler<Key>> action)
        {
            action(this);

            //return AbilityType switch
            //{
            //    AbilityType.Active => new ActiveAbility<Key>(Identity),
            //    AbilityType.Passive => new PassiveAbility<Key>(Identity),
            //    _ => throw new NotImplementedException()
            //};

            return null;
        }
    }
}