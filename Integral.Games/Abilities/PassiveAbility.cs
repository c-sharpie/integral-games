using Integral.Aggregates;
using Integral.Compositions;
using Integral.Conditions;
using Integral.Consumers;
using Integral.Registries;

namespace Integral.Abilities
{
    internal sealed class PassiveAbility<Key> : ActiveAbility<Key>
        where Key : notnull
    {
        internal PassiveAbility(Key key, Consumer<Composition> consumer, Registry<Composition, DirectAggregate<Condition>> registry) : base(key, consumer, registry)
        {
        }

        public override void Register(Composition composition)
        {
            base.Register(composition);
            OnPublish += Validate;
        }

        public override void Unregister(Composition composition)
        {
            OnPublish -= Validate;
            base.Unregister(composition);
        }

        private void Validate(bool valid)
        {
            if (valid)
            {
                Override();
            }
        }
    }
}