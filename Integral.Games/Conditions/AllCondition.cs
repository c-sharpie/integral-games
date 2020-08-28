using Integral.Aggregates;

namespace Integral.Conditions
{
    public sealed class AllCondition : PublishedCondition, DirectAggregate<Condition>
    {
        private int active, count;

        public AllCondition(bool value = default) : base(value)
        {
        }

        public bool Add(Condition condition)
        {
            count++;
            condition.OnPublish += Publish;
            if (condition.Enabled)
            {
                active++;
            }
            else
            {
                Value = false;
            }

            return true;
        }

        public bool Remove(Condition condition)
        {
            count--;
            condition.OnPublish -= Publish;
            if (condition.Enabled)
            {
                active--;
            }
            else if (active == count)
            {
                Value = true;
            }

            return true;
        }

        private void Publish(bool value)
        {
            if (value)
            {
                if (++active == count)
                {
                    Value = true;
                }
            }
            else
            {
                active--;
                Value = false;
            }
        }
    }
}