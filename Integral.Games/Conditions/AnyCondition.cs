using Integral.Aggregates;

namespace Integral.Conditions
{
    public class AnyCondition : PublishedCondition, DirectAggregate<Condition>
    {
        private int active;

        public AnyCondition(bool @default = default) : base(@default)
        {
        }

        public bool Add(Condition condition)
        {
            condition.OnPublish += Publish;
            if (condition.Enabled)
            {
                active++;
                Value = true;
            }

            return true;
        }

        public bool Remove(Condition condition)
        {
            condition.OnPublish -= Publish;
            if (condition.Enabled && --active == 0)
            {
                Value = false;
            }

            return true;
        }

        private void Publish(bool value)
        {
            if (value)
            {
                Value = true;
            }
            else if (--active == 0)
            {
                Value = false;
            }
        }
    }
}