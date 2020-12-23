using Integral.Abstractions;
using Integral.Collections;

namespace Adonai.Structures
{
    public interface Node<Key> : DirectCollection<int, Edge<Key>>, Identifiable<Key>
        where Key : notnull
    {
    }
}