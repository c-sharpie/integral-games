using Integral.Formulae;
using Integral.Statistics;

namespace Integral.Actors
{
    internal sealed class TestActor : Actor
    {
        private readonly TransientStatistic experience = new TransientStatistic(), health = new TransientStatistic();

        private readonly CalculatedStatistic level;

        private readonly ClampedStatistic clampedHealth;

        private readonly AggregateStatistic maxHealth = new MultipliedStatistic();

        internal TestActor()
        {
            this.level = new CalculatedStatistic(new TestLevelFormula(), experience);

            AggregateStatistic maxHealthLevelMultiplier = new MultipliedStatistic();
            maxHealthLevelMultiplier.Register(level);
            maxHealthLevelMultiplier.Register(new ConstantStatistic(200));

            AggregateStatistic maxHealthValues = new SummedStatistic();
            maxHealthValues.Register(maxHealthLevelMultiplier);

            AggregateStatistic maxHealthMultipliers = new SummedStatistic();

            maxHealth.Register(maxHealthValues);
            maxHealth.Register(maxHealthMultipliers);

            clampedHealth = new ClampedStatistic(new ConstantStatistic(0), maxHealth, health);
        }

        public int Experience
        {
            get => (int)experience.Value;
            set => experience.Value = value;
        }

        public int Level => (int)level.Value;

        public int Health
        {
            get => (int)clampedHealth.Value;
            set => health.Value = value;
        }

        public int MaxHealth => (int)maxHealth.Value;
    }
}
