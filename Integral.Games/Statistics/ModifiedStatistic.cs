namespace Integral.Statistics
{
    public class ModifiedStatistic : MultipliedStatistic
    {
        public ModifiedStatistic()
        {
            Register(Values);
            Register(Modifiers);
        }

        public AggregateStatistic Values { get; } = new SummedStatistic();

        public AggregateStatistic Modifiers { get; } = new SummedStatistic();
    }
}
