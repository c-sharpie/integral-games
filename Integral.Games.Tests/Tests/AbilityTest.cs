using Integral.Abilities;
using Integral.Actors;
using Integral.Builders;
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

            AbilityBuilder abilityBuilder = new AbilityBuilder();
            Ability ability = abilityBuilder.Build(abilityAssembler => { });

            timer.Elapse(2);
            ability.Execute();

            Assert.IsTrue(testActor.Executed);
        }

        [TestMethod]
        public void PassiveTest()
        {
            Timer timer = timerFactory.Create();
            TestActor testActor = new TestActor(timer);

            AbilityBuilder abilityBuilder = new AbilityBuilder();
            Ability ability = abilityBuilder.Build(abilityAssembler => { });

            timer.Elapse(2);

            Assert.IsTrue(testActor.Executed);
        }
    }
}