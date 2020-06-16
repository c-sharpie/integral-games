using Integral.Conditions;

namespace Integral.Commands
{
    public interface ConditionalCommand : Condition, Command
    {
        void Override();
    }
}