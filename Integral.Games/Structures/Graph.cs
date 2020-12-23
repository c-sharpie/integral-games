using Integral.Collections;

namespace Adonai.Structures
{
    public interface Graph<Key> : KeyedCollection<Key, Node<Key>>
        where Key : notnull
    {
    }
}