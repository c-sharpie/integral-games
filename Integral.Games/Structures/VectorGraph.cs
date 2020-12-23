using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Adonai.Enumerations;
using Integral.Collections;
using Integral.Constructors;

namespace Adonai.Structures
{
    internal sealed class VectorGraph : IdentifiableCollection<Vector3, Node<Vector3>>, Graph<Vector3>
    {
        internal VectorGraph(IEnumerable<Vector3> vectors) : base(new IndexedCollection<Vector3, Node<Vector3>>())
        {
            int length = 1 + (int)vectors.Max(x => x.X);
            int width = 1 + (int)vectors.Max(x => x.Z);
            VectorNode[][] nodes = ArrayConstructor.Create<VectorNode>(length, width);
            foreach (Vector3 node in vectors)
            {
                VectorNode vectorNode = new VectorNode(node, TerrainType.Grass);
                nodes[(int)vectorNode.Identity.X][(int)vectorNode.Identity.Z] = vectorNode;
                Add(vectorNode);
            }

            for (byte i = 0; i < length; i++)
            {
                for (byte ii = 0; ii < width; ii++)
                {
                    VectorNode node = nodes[i][ii];
                    if (node != null)
                    {
                        if (i > 0)
                        {
                            VectorNode neighbor = nodes[i - 1][ii];
                            if (neighbor != null)
                            {
                                node.Add(new VectorEdge(neighbor));
                            }
                        }

                        if (i < length - 1)
                        {
                            VectorNode neighbor = nodes[i + 1][ii];
                            if (neighbor != null)
                            {
                                node.Add(new VectorEdge(neighbor));
                            }
                        }

                        if (ii > 0)
                        {
                            VectorNode neighbor = nodes[i][ii - 1];
                            if (neighbor != null)
                            {
                                node.Add(new VectorEdge(neighbor));
                            }
                        }

                        if (ii < width - 1)
                        {
                            VectorNode neighbor = nodes[i][ii + 1];
                            if (neighbor != null)
                            {
                                node.Add(new VectorEdge(neighbor));
                            }
                        }
                    }
                }
            }
        }
    }
}