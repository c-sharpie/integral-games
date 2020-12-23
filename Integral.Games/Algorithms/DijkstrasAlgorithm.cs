using System;
using System.Collections.Generic;
using System.Numerics;
using Adonai.Structures;
using Integral.Collections;

namespace Adonai.Algorithms
{
    public static class DijkstrasAlgorithm
    {
        public static IndirectCollection<Node<Vector3>> Calculate(Node<Vector3> source, Node<Vector3> destination, Func<Node<Vector3>, Node<Vector3>, float> weight)
        {
            Dictionary<Node<Vector3>, Node<Vector3>> steps = new Dictionary<Node<Vector3>, Node<Vector3>>();
            Dictionary<Node<Vector3>, float> cost = new Dictionary<Node<Vector3>, float>();
            cost.Add(source, 0);

            throw new NotImplementedException();
            //PriorityCollection<Node<Vector3>, float> frontier = new WeightedCollection<Node<Vector3>>();
            //frontier.Add(source, 0);

            //while (frontier.Count > 0)
            //{
            //    if (frontier.Remove(out Node<Vector3> node))
            //    {
            //        if (!node.Equals(destination))
            //        {
            //            foreach (Edge<Vector3> edge in node)
            //            {
            //                Node<Vector3> neighbor = edge.Node;
            //                float total = cost[node] + edge.Weight + weight(node, neighbor);
            //                if (!cost.ContainsKey(neighbor) || total < cost[neighbor])
            //                {
            //                    frontier.Add(neighbor, total + ManhattanDistance(neighbor.Identity, destination.Identity));
            //                    cost[neighbor] = total;
            //                    steps[neighbor] = node;
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        throw new Exception();
            //    }
            //}

            //StackedCollection<Node<Vector3>> path = new StackedCollection<Node<Vector3>>();
            //Node<Vector3> step = destination;
            //path.Add(step);
            //while (step != source)
            //{
            //    step = steps[step];
            //    path.Add(step);
            //}

            //return path;
        }

        private static float ManhattanDistance(Vector3 a, Vector3 b) => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }
}