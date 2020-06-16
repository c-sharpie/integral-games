using Integral.Abilities;
using Integral.Collections;

namespace Integral.Components
{
    public interface AbilityComponent<Key> : DirectCollection<Key, Ability<Key>>, Component
        where Key : notnull
    {
    }
}