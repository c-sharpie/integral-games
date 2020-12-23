using System.Collections.Generic;
using Adonai.Enumerations;
using Adonai.Structures;

namespace Adonai.Components
{
    public interface RangefinderComponent<Key>
        where Key : notnull
    {
        bool Range(Node<Key> source, Node<Key> destination);

        bool Range(Node<Key> source, Node<Key> destination, SelectionShape selectionShape, int magnitude, out IEnumerable<Node<Key>> selectedNodes);
    }
}