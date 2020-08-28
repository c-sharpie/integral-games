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
        public void SimpleTest()
        {
            GenericPublisher<float> experiencePublisher = new GenericPublisher<float>();
            GenericPublisher<float> primaryPublisher = new GenericPublisher<float>();
            GenericPublisher<float> multiplierPublisher = new GenericPublisher<float>();

            Statistic experience = new DelegatedStatistic(experiencePublisher);
            Statistic level = new CalculatedStatistic(new TestLevelFormula(), experience);
            Statistic primary = new DelegatedStatistic(primaryPublisher);
            Statistic secondary = new MultipliedStatistic(new[] { primary, new DelegatedStatistic(multiplierPublisher, 2) });

            experiencePublisher.Publish(1000);
            primaryPublisher.Publish(2);

            Assert.AreEqual(level.Value, 4);
            Assert.AreEqual(secondary.Value, 2 * 2);
        }
    }
}