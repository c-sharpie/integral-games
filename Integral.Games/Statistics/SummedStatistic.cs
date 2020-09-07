namespace Integral.Statistics
{
    public sealed class SummedStatistic : RegisteredStatistic
    {
        public override void Register(Statistic statistic) => Value += statistic.Value;

        public override void Unregister(Statistic statistic) => Value -= statistic.Value;

        protected override void Change(int previousValue, int currentValue) => Value += currentValue - previousValue;
    }
}