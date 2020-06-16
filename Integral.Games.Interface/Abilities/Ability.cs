using Integral.Abstractions;
using Integral.Commands;
using Integral.Compositions;
using Integral.Notifiers;
using Integral.Registries;

namespace Integral.Abilities
{
    public interface Ability<out Key> : Registry<Composition>, Identifiable<Key>, Notifier, Command
        where Key : notnull
    {
    }
}