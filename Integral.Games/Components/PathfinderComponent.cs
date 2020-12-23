using Adonai.Structures;
using Integral.Collections;

namespace Adonai.Components
{
    public interface PathfinderComponent<Key>
        where Key : notnull
    {
        bool Paths(Node<Key> source, Node<Key> destination, out DirectCollection<int, IndirectCollection<Node<Key>>> paths);
    }
}