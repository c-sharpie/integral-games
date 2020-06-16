namespace Integral.Formulae
{
    public interface AbilityFormula<in Actor, in Target>
    {
        void Evaluate(Actor actor, Target target);
    }
}