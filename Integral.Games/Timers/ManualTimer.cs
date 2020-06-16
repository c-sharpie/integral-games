﻿namespace Integral.Timers
{
    internal sealed class ManualTimer : IntervalTimer
    {
        private readonly double interval;

        private double current;

        internal ManualTimer(double interval) => this.interval = interval;

        public override void Elapse(double time)
        {
            if (current < interval)
            {
                current += time;
                if (current >= interval)
                {
                    Execute();
                }
            }
        }

        public override void Reset() => current = 0;
    }
}