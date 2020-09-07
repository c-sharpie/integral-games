using Integral.Formulae;
using Integral.Statistics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Integral.Tests
{
    [TestClass]
    public class StatisticTest
    {
        [TestMethod]
        public void Test()
        {
            TransientStatistic experience = new TransientStatistic();
            ObservedStatistic level = new CalculatedStatistic(new TestLevelFormula(), experience);

            TransientStatistic healthMultiplier = new TransientStatistic();

            AggregateStatistic health = new MultipliedStatistic();
            health.Register(level);
            health.Register(healthMultiplier);

            experience.Value = 1000;
            healthMultiplier.Value = 200;

            Assert.AreEqual(level.Value, 4);
            Assert.AreEqual(health.Value, level.Value * 200);
        }
    }
}