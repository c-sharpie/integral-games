namespace Integral.Formulae
{
    public interface ApplyFormula<in Source, in Target>
    {
        void Evaluate(Source source, Target target);
    }
}