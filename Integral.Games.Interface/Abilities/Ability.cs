using Integral.Abstractions;
using Integral.Commands;
using Integral.Notifiers;

namespace Integral.Abilities
{
    public interface Ability<out Key> : Identifiable<Key>, Notifier, Command
        where Key : notnull
    {
    }
}