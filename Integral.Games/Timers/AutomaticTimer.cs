﻿namespace Integral.Timers
{
    public sealed class AutomaticTimer : IntervalTimer
    {
        private readonly double interval;

        private double current;

        public AutomaticTimer(double interval) => this.interval = interval;

        public override void Elapse(double time)
        {
            current += time;
            while (current >= interval)
            {
                current -= interval;
                Execute();
            }
        }

        public override void Reset() => current = 0;
    }
}