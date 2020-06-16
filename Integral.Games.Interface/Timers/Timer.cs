using Integral.Notifiers;

namespace Integral.Timers
{
    public interface Timer : Notifier
    {
        void Elapse(double time);

        void Reset();
    }
}