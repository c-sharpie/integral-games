using Integral.Observers;

namespace Integral.Conditions
{
    public abstract class ObserverCondition<Observable> : PublishedCondition
        where Observable : notnull
    {
        protected ObserverCondition(Observer<Observable> observer) => observer.OnChange += OnChange;

        protected abstract bool Evaluate(Observable previous, Observable current);

        private void OnChange(Observable previous, Observable current) => Value = Evaluate(previous, current);
    }
}