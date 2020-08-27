using System;
using Integral.Assemblers;
using Integral.Formulae;
using Integral.Publishers;
using Integral.Statistics;

namespace Integral.Builders
{
    public sealed class StatisticBuilder : Builder<Statistic, StatisticAssembler>
    {
        public Statistic Build(Action<StatisticAssembler> statisticAssemblerAction)
        {
            Assembler assembler = new Assembler();
            statisticAssemblerAction(assembler);
            return assembler.Statistic!;
        }

        private sealed class Assembler : StatisticAssembler
        {
            internal Statistic? Statistic { get; private set; }

            public void Add(float value) => Add(new ObservedStatistic(value));

            public void Add(Publisher<float> publisher, float value = 0) => Add(new DelegatedStatistic(publisher, value));

            public void Add(Statistic statistic) => Aggregate(statistic, () => new SummedStatistic(new[] { Statistic!, statistic }));

            public void Multiply(float value) => Multiply(new ObservedStatistic(value));

            public void Multiply(Publisher<float> publisher, float value = 0) => Multiply(new DelegatedStatistic(publisher, value));

            public void Multiply(Statistic statistic) => Aggregate(statistic, () => new MultipliedStatistic(new[] { Statistic!, statistic }));

            public void Calculate(DeltaFormula<float> formula, float value = 0) => Statistic = new CalculatedStatistic(formula, Statistic ?? new ObservedStatistic(), value);

            private void Aggregate<T>(Statistic statistic, Func<T> factory)
                where T : AggregateStatistic
            {
                if (Statistic == null)
                {
                    Statistic = statistic;
                }
                else if (statistic is T)
                {
                    ((T)statistic).Subscribe(statistic);
                }
                else
                {
                    Statistic = factory();
                }
            }
        }
    }
}