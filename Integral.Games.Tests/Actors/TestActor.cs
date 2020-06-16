using System;
using Integral.Abstractions;
using Integral.Aggregates;
using Integral.Compositions;
using Integral.Conditions;
using Integral.Consumers;
using Integral.Registries;
using Integral.Timers;

namespace Integral.Actors
{
    internal sealed class TestActor : Executable, Consumer<Composition>, Registry<Composition, DirectAggregate<Condition>>
    {
        private readonly Condition condition;

        public TestActor(Timer timer) => condition = new ToggleCondition(timer);

        internal bool Executed { get; set; }

        public void Execute() => Executed = true;

        public void Consume(Composition composition) => Execute();

        public void Register(Composition registrant, DirectAggregate<Condition> registrar)
        {
            registrar.Add(condition);
        }

        public void Unregister(Composition registrant, DirectAggregate<Condition> registrar)
        {
            //registrar.Remove(condition);
            throw new NotImplementedException();
        }
    }
}