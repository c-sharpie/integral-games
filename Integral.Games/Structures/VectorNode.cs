using System.Numerics;
using Adonai.Enumerations;
using Integral.Collections;

namespace Adonai.Structures
{
    internal sealed class VectorNode : ListedCollection<Edge<Vector3>>, Node<Vector3>
    {
        internal VectorNode(Vector3 identity, TerrainType terrainType)
        {
            Identity = identity;
            TerrainType = terrainType;
        }

        public Vector3 Identity { get; set; }

        public TerrainType TerrainType { get; set; }
    }
}