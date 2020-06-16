using Integral.Abilities;
using Integral.Aggregates;

namespace Integral.Assemblers
{
    public interface AbilityComponentAssembler<in Key> : DirectAggregate<Ability<Key>>
        where Key : notnull
    {
    }
}