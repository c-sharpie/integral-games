namespace Integral.Formulae
{
    public interface DeltaFormula<Value>
    {
        Value Evaluate(Value previous, Value current);
    }
}