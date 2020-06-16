using System;

namespace Integral.Timers
{
    internal abstract class IntervalTimer : Timer
    {
        public event Action? OnNotify;

        public abstract void Elapse(double time);

        public abstract void Reset();

        protected void Execute() => OnNotify?.Invoke();
    }
}