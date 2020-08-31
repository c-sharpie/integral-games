using Integral.Formulae;
using Integral.Publishers;
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
            GenericPublisher<int> experiencePublisher = new GenericPublisher<int>();
            GenericPublisher<int> healthMultiplierPublisher = new GenericPublisher<int>();

            Statistic experience = new DelegatedStatistic(experiencePublisher, 1000);
            Statistic level = new CalculatedStatistic(new TestLevelFormula(), experience);

            Statistic healthMultiplier = new DelegatedStatistic(healthMultiplierPublisher, 200);
            Statistic health = new MultipliedStatistic(new[] { level, healthMultiplier });

            Assert.AreEqual(level.Value, 4);
            Assert.AreEqual(health.Value, level.Value * 200);
        }
    }
}