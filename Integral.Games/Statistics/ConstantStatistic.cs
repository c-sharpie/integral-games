namespace Integral.Statistics
{
    public sealed class ConstantStatistic : ReadOnlyStatistic
    {
        public ConstantStatistic(int value = default) => Value = value;

        public int Value { get; }
    }
}
