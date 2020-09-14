namespace Integral.Statistics
{
    public sealed class ModifiedStatistic : AbstractStatistic<MultipliedStatistic>
    {
        public ModifiedStatistic()
        {
            Statistic.Register(Modifier);
            Statistic.Register(Baseline);
        }

        public AggregateStatistic Modifier { get; } = new SummedStatistic();

        public AggregateStatistic Baseline { get; } = new SummedStatistic();
    }
}
