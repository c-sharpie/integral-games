using Integral.Abilities;
using Integral.Actors;
using Integral.Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Integral.Tests
{
    [TestClass]
    public class StatisticTest
    {
        [TestMethod]
        public void Test()
        {
            TestActor testActor = new TestActor();
            testActor.Experience = 1000;

            TestAbility testAbility = new TestAbility();
            testAbility.Apply(testActor);

            TestItem testItem = new TestItem();
            testItem.Bind(testActor);

            Assert.AreEqual(testActor.Level, 4);
            Assert.AreEqual(testActor.MaxHealth, testActor.Level * 200);
        }
    }
}