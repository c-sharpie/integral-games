using System;
using Integral.Abilities;
using Integral.Assemblers;

namespace Integral.Builders
{
    public sealed class AbilityBuilder : Builder<Ability, AbilityAssembler>
    {
        public Ability Build(Action<AbilityAssembler> abilityAssemblerAction)
        {
            Assembler assembler = new Assembler();
            abilityAssemblerAction(assembler);
            return assembler.Assemble();
        }

        private sealed class Assembler : AbilityAssembler
        {
            internal Ability Assemble()
            {
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
}