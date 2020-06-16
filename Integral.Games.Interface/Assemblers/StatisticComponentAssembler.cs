using Integral.Formulae;
using Integral.Publishers;

namespace Integral.Assemblers
{
    public interface StatisticComponentAssembler<in T>
    {
        void AddConstant(T statistic, float value);

        void AddSummed(T statistic, params T[] sources);

        void AddMultiplied(T statistic, params T[] sources);

        void AddDelegated(T statistic, Publisher<float> publisher);

        void AddCalculated(T statistic, T source, StatisticFormula<float> formula);
    }
}