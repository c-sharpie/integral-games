using System;

namespace Integral.Formulae
{
    internal sealed class TestLevelFormula : DeltaFormula<float>
    {
        private const float ExperiencePower = 2, ExperienceMultiplier = 100;

        public float Evaluate(float previous, float current) => 1 + (float)Math.Truncate(Math.Pow(current / ExperienceMultiplier, 1 / ExperiencePower));
    }
}