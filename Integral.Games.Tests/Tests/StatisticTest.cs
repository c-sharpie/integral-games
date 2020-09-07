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

            ObservedStatistic experience = new TransientStatistic(experiencePublisher, 1000);
            ObservedStatistic level = new CalculatedStatistic(new TestLevelFormula(), experience);

            ObservedStatistic healthMultiplier = new TransientStatistic(healthMultiplierPublisher, 200);

            AggregateStatistic health = new MultipliedStatistic();
            health.Register(level);
            health.Register(healthMultiplier);

            Assert.AreEqual(level.Value, 4);
            Assert.AreEqual(health.Value, level.Value * 200);
        }
    }
}