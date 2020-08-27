using Integral.Formulae;
using Integral.Publishers;
using Integral.Statistics;

namespace Integral.Assemblers
{
    public interface StatisticAssembler
    {
        void Add(float value);

        void Add(Publisher<float> publisher, float value = 0);

        void Add(Statistic statistic);

        void Multiply(float value);

        void Multiply(Publisher<float> publisher, float value = 0);

        void Multiply(Statistic statistic);

        void Calculate(DeltaFormula<float> formula, float value = 0);
    }
}