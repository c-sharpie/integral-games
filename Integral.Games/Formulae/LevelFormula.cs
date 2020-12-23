using System;
using Integral.Formulae;

namespace Adonai.Formulae
{
    internal sealed class LevelFormula : DeltaFormula<float>
    {
        private const float ExperiencePower = 2, ExperienceMultiplier = 100;

        private float remaining, level = 1;

        public float Evaluate(float previous, float current)
        {
            remaining -= current - previous;
            if (remaining <= 0)
            {
                level = 1 + (float)Math.Truncate(Math.Pow(current / ExperienceMultiplier, 1 / ExperiencePower));
                remaining = (float)(Math.Pow(level, ExperiencePower) * ExperienceMultiplier);
            }

            return level;
        }
    }
}