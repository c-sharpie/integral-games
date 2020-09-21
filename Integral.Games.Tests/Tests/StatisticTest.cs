using Integral.Actors;
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

            Assert.AreEqual(testActor.Level, 4);
            Assert.AreEqual(testActor.MaxHealth, testActor.Level * 200);
        }
    }
}