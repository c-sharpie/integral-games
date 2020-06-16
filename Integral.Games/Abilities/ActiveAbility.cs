using System;
using Integral.Aggregates;
using Integral.Collections;
using Integral.Compositions;
using Integral.Conditions;
using Integral.Consumers;
using Integral.Registries;

namespace Integral.Abilities
{
    internal class ActiveAbility<Key> : AnyCondition, Ability<Key>
        where Key : notnull
    {
        private readonly Consumer<Composition> consumer;

        private readonly Registry<Composition, DirectAggregate<Condition>> registry;

        private readonly DirectCollection<int, Composition> compositions = new ListedCollection<Composition>();

        internal ActiveAbility(Key key, Consumer<Composition> consumer, Registry<Composition, DirectAggregate<Condition>> registry)
        {
            Identity = key;
            this.consumer = consumer;
            this.registry = registry;
        }

        public event Action? OnNotify;

        public Key Identity { get; }

        public void Execute()
        {
            if (Value)
            {
                Override();
            }
        }

        public void Override()
        {
            OnNotify?.Invoke();
            foreach (Composition composition in compositions)
            {
                consumer.Consume(composition);
            }
        }

        public virtual void Register(Composition composition)
        {
            compositions.Add(composition);
            registry.Register(composition, this);
        }

        public virtual void Unregister(Composition composition)
        {
            compositions.Remove(composition);
            registry.Unregister(composition, this);
        }
    }
}