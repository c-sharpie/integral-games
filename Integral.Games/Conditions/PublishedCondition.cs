using Integral.Publishers;

namespace Integral.Conditions
{
    public abstract class PublishedCondition : ValuePublisher<bool>, Condition
    {
        protected PublishedCondition(bool value = default) : base(value)
        {
        }

        public bool Enabled => Value;
    }
}
