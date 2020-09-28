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
            TransientStatistic experience = new TransientStatistic(1000);
            CalculatedStatistic level = new CalculatedStatistic(new TestLevelFormula(), experience);

            MultipliedStatistic maxHealthLevelMultiplier = new MultipliedStatistic();
            maxHealthLevelMultiplier.Register(level);
            maxHealthLevelMultiplier.Register(new ConstantStatistic(200));

            SummedStatistic maxHealthValues = new SummedStatistic();
            maxHealthValues.Register(maxHealthLevelMultiplier);

            SummedStatistic maxHealthMultipliers = new SummedStatistic();

            MultipliedStatistic maxHealth = new MultipliedStatistic();
            maxHealth.Register(maxHealthValues);
            maxHealth.Register(maxHealthMultipliers);

            TransientStatistic health = new TransientStatistic(maxHealth.Value);
            ClampedStatistic clampedHealth = new ClampedStatistic(new ConstantStatistic(0), maxHealth, health);

            Assert.AreEqual(level.Value, 4);
            Assert.AreEqual(clampedHealth.Value, level.Value * 200);
        }
    }
}