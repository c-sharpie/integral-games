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
            GenericPublisher<float> experiencePublisher = new GenericPublisher<float>();
            GenericPublisher<float> healthMultiplierPublisher = new GenericPublisher<float>();

            Statistic experience = new DelegatedStatistic(experiencePublisher);
            Statistic level = new CalculatedStatistic(new TestLevelFormula(), experience);

            Statistic healthMultiplier = new DelegatedStatistic(healthMultiplierPublisher, 200);
            Statistic health = new MultipliedStatistic(new[] { level, healthMultiplier });

            experiencePublisher.Publish(1000);

            Assert.AreEqual(level.Value, 4);
            Assert.AreEqual(health.Value, level.Value * 200);
        }
    }
}