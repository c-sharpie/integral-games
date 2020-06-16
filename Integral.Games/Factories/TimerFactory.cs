using Integral.Timers;

namespace Integral.Factories
{
    public sealed class TimerFactory : Factory<Timer>
    {
        public bool Manual { get; set; } = true;

        public double Interval { get; set; } = 1;

        public Timer Create() => Manual ? new ManualTimer(Interval) : new AutomaticTimer(Interval) as Timer;
    }
}