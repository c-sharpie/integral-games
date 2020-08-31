using System;

namespace Integral.Formulae
{
    internal sealed class TestLevelFormula : DeltaFormula<int>
    {
        private const float ExperiencePower = 2, ExperienceMultiplier = 100;

        public int Evaluate(int previous, int current) => 1 + (int)Math.Truncate(Math.Pow(current / ExperienceMultiplier, 1 / ExperiencePower));
    }
}