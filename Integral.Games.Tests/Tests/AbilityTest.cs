using Integral.Abilities;
using Integral.Actors;
using Integral.Builders;
using Integral.Enumerations;
using Integral.Factories;
using Integral.Timers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Integral.Tests
{
    [TestClass]
    public class AbilityTest
    {
        private readonly TimerFactory timerFactory = new TimerFactory();

        [TestMethod]
        public void ActiveTest()
        {
            Timer timer = timerFactory.Create();
            TestActor testActor = new TestActor(timer);

            AbilityFactory<AbilityType> abilityFactory = new AbilityFactory<AbilityType>(AbilityType.Active);
            abilityFactory.AbilityType = AbilityType.Active;
            //abilityFactory.Consumer = testActor;
            //abilityFactory.Registry = testActor;
            Ability<AbilityType> ability = abilityFactory.Create();

            AbilityBuilder<AbilityType> abilityComponentBuilder = new AbilityBuilder<AbilityType>();
            AbilityComponent<AbilityType> abilityComponent = abilityComponentBuilder.Build(x => { });
            abilityComponent.Add(ability);

            timer.Elapse(2);
            ability.Execute();

            Assert.IsTrue(testActor.Executed);
        }

        [TestMethod]
        public void PassiveTest()
        {
            Timer timer = timerFactory.Create();
            TestActor testActor = new TestActor(timer);

            AbilityFactory<AbilityType> abilityFactory = new AbilityFactory<AbilityType>(AbilityType.Passive);
            abilityFactory.AbilityType = AbilityType.Passive;
            //abilityFactory.Consumer = testActor;
            //abilityFactory.Registry = testActor;
            Ability<AbilityType> ability = abilityFactory.Create();

            AbilityBuilder<AbilityType> abilityComponentBuilder = new AbilityBuilder<AbilityType>();
            AbilityComponent<AbilityType> abilityComponent = abilityComponentBuilder.Build(x => { });
            abilityComponent.Add(ability);

            timer.Elapse(2);

            Assert.IsTrue(testActor.Executed);
        }
    }
}