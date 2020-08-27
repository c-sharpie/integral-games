using System;
using Integral.Conditions;

namespace Integral.Abilities
{
    public class ActiveAbility : AnyCondition, Ability
    {
        public event Action? OnNotify;

        public void Execute()
        {
            if (Value)
            {
                Override();
            }
        }

        public void Override() => OnNotify?.Invoke();
    }
}