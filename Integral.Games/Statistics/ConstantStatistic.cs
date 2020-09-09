namespace Integral.Statistics
{
    public sealed class ConstantStatistic : ReadOnlyStatistic
    {
        public ConstantStatistic(float value = default) => Value = value;

        public float Value { get; }
    }
}
