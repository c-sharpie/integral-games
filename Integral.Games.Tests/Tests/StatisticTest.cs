using System;
using Integral.Assemblers;
using Integral.Builders;
using Integral.Components;
using Integral.Enumerations;
using Integral.Formulae;
using Integral.Publishers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Integral.Tests
{
    [TestClass]
    public class StatisticTest
    {
        [TestMethod]
        public void MultiplicationTest()
        {
            GenericPublisher<float> primaryStatisticPublisher1 = new GenericPublisher<float>();
            GenericPublisher<float> primaryStatisticPublisher2 = new GenericPublisher<float>();
            GenericPublisher<float> primaryStatisticPublisher3 = new GenericPublisher<float>();

            void Assemble(StatisticComponentAssembler<TestStatistics> statisticsComponentAssembler)
            {
                statisticsComponentAssembler.AddDelegated(TestStatistics.Secondary, primaryStatisticPublisher1);
                statisticsComponentAssembler.AddDelegated(TestStatistics.SourcedSecondary, primaryStatisticPublisher2);
                statisticsComponentAssembler.AddDelegated(TestStatistics.ScaledSecondary, primaryStatisticPublisher3);
                statisticsComponentAssembler.AddMultiplied(TestStatistics.TotalSecondary, TestStatistics.Secondary, TestStatistics.SourcedSecondary, TestStatistics.ScaledSecondary);
            }

            StatisticComponentBuilder<TestStatistics> statisticComponentBuilder = new StatisticComponentBuilder<TestStatistics>();
            StatisticComponent<TestStatistics> statisticComponent = statisticComponentBuilder.Build(Assemble);

            const int iterations = 1000, count = 10, max = 10;
            Random random = new Random();
            float[] values = new float[count];
            for (int i = 0; i < count; i++)
            {
                values[i] = random.Next() % max;
            }

            for (int i = 0; i < iterations; i++)
            {
                float value1 = values[i % count];
                float value2 = values[(i + 1) % count];
                float value3 = values[(i + 2) % count];
                primaryStatisticPublisher1.Publish(value1);
                primaryStatisticPublisher2.Publish(value2);
                primaryStatisticPublisher3.Publish(value3);
                float result1 = value1 * value2 * value3;
                float result2 = statisticComponent[TestStatistics.TotalSecondary].Value;
                Assert.AreEqual(result1, result2);
            }
        }

        [TestMethod]
        public void CollectionTest()
        {
            GenericPublisher<float> experiencePublisher = new GenericPublisher<float>();
            GenericPublisher<float> primaryStatisticPublisher = new GenericPublisher<float>();

            void Assemble(StatisticComponentAssembler<TestStatistics> statisticsComponentAssembler)
            {
                statisticsComponentAssembler.AddDelegated(TestStatistics.Experience, experiencePublisher);
                statisticsComponentAssembler.AddCalculated(TestStatistics.Level, TestStatistics.Experience, new TestLevelFormula());

                statisticsComponentAssembler.AddDelegated(TestStatistics.Primary, primaryStatisticPublisher);
                statisticsComponentAssembler.AddSummed(TestStatistics.SourcedPrimary);
                statisticsComponentAssembler.AddSummed(TestStatistics.TotalPrimary, TestStatistics.Primary, TestStatistics.SourcedPrimary);

                statisticsComponentAssembler.AddConstant(TestStatistics.Secondary, 0.5f);
                statisticsComponentAssembler.AddMultiplied(TestStatistics.ScaledSecondary, TestStatistics.Secondary, TestStatistics.Level);
                statisticsComponentAssembler.AddSummed(TestStatistics.SourcedSecondary);
                statisticsComponentAssembler.AddSummed(TestStatistics.TotalSecondary, TestStatistics.Secondary, TestStatistics.SourcedSecondary);
            }

            StatisticComponentBuilder<TestStatistics> statisticComponentBuilder = new StatisticComponentBuilder<TestStatistics>();
            StatisticComponent<TestStatistics> statisticComponent = statisticComponentBuilder.Build(Assemble);

            experiencePublisher.Publish(1000);
            primaryStatisticPublisher.Publish(5);
            Assert.AreEqual(statisticComponent[TestStatistics.Level].Value, 4);
            Assert.AreEqual(statisticComponent[TestStatistics.Secondary].Value, 0.5);
            Assert.AreEqual(statisticComponent[TestStatistics.ScaledSecondary].Value, 2);
        }
    }
}