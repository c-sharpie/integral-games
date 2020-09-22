namespace Integral.Statistics
{
    public class ConstantStatistic : ReadOnlyStatistic
    {
        public ConstantStatistic(float value = default) => Value = value;

        public float Value { get; }
    }
}
