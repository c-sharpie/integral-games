﻿namespace Integral.Conditions
{
    public sealed class InverseCondition : PublishedCondition
    {
        public InverseCondition(Condition condition) => condition.OnPublish += Inverse;

        private void Inverse(bool value) => Value = !value;
    }
}