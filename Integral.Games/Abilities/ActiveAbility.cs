using System;
using Integral.Conditions;

namespace Integral.Abilities
{
    internal class ActiveAbility<Key> : AnyCondition, Ability<Key>
        where Key : notnull
    {
        internal ActiveAbility(Key key) => Identity = key;

        public event Action? OnNotify;

        public Key Identity { get; }

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