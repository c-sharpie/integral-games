namespace Integral.Conditions
{
    public class InverseCondition : PublishedCondition
    {
        public InverseCondition(Condition condition) => condition.OnPublish += Inverse;

        private void Inverse(bool value) => Value = !value;
    }
}