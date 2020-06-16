using Integral.Abstractions;

namespace Integral.Items
{
    public interface Item<out Key> : Identifiable<Key>
        where Key : notnull
    {
    }
}