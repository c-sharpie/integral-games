using Integral.Publishers;

namespace Integral.Conditions
{
    public abstract class PublishedCondition : ValuePublisher<bool>, Condition
    {
        protected PublishedCondition(bool @default = default) : base(@default)
        {
        }

        public bool Enabled => Value;
    }
}
