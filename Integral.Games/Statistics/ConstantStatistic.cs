namespace Integral.Statistics
{
    public sealed class ConstantStatistic : Statistic
    {
        public ConstantStatistic(int value = default) => Value = value;

        public int Value { get; }
    }
}
