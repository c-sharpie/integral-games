using System.Numerics;

namespace Adonai.Structures
{
    internal sealed class VectorEdge : Edge<Vector3>
    {
        internal VectorEdge(Node<Vector3> node) => Node = node;

        public Node<Vector3> Node { get; }

        public float Weight { get; set; } = 1;
    }
}