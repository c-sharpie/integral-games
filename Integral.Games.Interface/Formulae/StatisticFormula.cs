namespace Integral.Formulae
{
    public interface StatisticFormula<Statistic>
    {
        Statistic Evaluate(Statistic previous, Statistic current);
    }
}