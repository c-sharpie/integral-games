using Integral.Notifiers;

namespace Integral.Conditions
{
    public abstract class EventCondition : PublishedCondition
    {
        protected EventCondition(Notifier notifier) => notifier.OnNotify += OnEvent;

        protected abstract bool Validate();

        private void OnEvent() => Value = Validate();
    }
}