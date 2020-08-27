using Integral.Builders;
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
        public void BuilderTest()
        {
            GenericPublisher<float> experiencePublisher = new GenericPublisher<float>();
            GenericPublisher<float> primaryPublisher = new GenericPublisher<float>();

            StatisticBuilder statisticBuilder = new StatisticBuilder();
            Statistic experience = statisticBuilder.Build(statisticAssembler => statisticAssembler.Add(experiencePublisher));
            Statistic level = statisticBuilder.Build(statisticAssembler =>
            {
                statisticAssembler.Add(experience);
                statisticAssembler.Calculate(new TestLevelFormula());
            });

            Statistic primary = statisticBuilder.Build(statisticAssembler => statisticAssembler.Add(primaryPublisher));
            Statistic secondary = statisticBuilder.Build(statisticAssembler =>
            {
                statisticAssembler.Multiply(primary);
                statisticAssembler.Multiply(2);
            });

            experiencePublisher.Publish(1000);
            primaryPublisher.Publish(2);

            Assert.AreEqual(level.Value, 4);
            Assert.AreEqual(secondary.Value, 2 * 2);
        }
    }
}