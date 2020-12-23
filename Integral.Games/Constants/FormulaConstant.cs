using Adonai.Formulae;
using Integral.Formulae;

namespace Adonai.Constants
{
    public static class FormulaConstant
    {
        public static DeltaFormula<float> Experience => new LevelFormula();
    }
}