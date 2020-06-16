using Integral.Notifiers;

namespace Integral.Conditions
{
    public sealed class ToggleCondition : PublishedCondition
    {
        public ToggleCondition(Notifier notifier) => notifier.OnNotify += Toggle;

        private void Toggle() => Value = !Value;
    }
}