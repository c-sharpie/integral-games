using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adonai.Tests
{
    [TestClass]
    public class GraphTest
    {
        [TestMethod]
        public void TestMethod()
        {
            /*
             * 2 4
             * 1 3
             */

            //GraphModel graphModel;
            //using Stream stream = File.OpenRead(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "map.txt"));
            //MementoFactory<GraphModel> mementoFactory = new MementoFactory<GraphModel>();
            //mementoFactory.Stream = stream;
            //Memento<GraphModel> memento = mementoFactory.Create();
            //graphModel = memento.Load();

            //TestNode node1 = new TestNode(new Vector3 { x = 0, y = 0, z = 0 });
            //TestNode node2 = new TestNode(new Vector3 { x = 0, y = 1, z = 0 });
            //TestNode node3 = new TestNode(new Vector3 { x = 1, y = 0, z = 0 });
            //TestNode node4 = new TestNode(new Vector3 { x = 1, y = 1, z = 0 });

            //node1.Add(new TestEdge(node2));
            //node1.Add(new TestEdge(node3));
            //node2.Add(new TestEdge(node1));
            //node2.Add(new TestEdge(node4));
            //node3.Add(new TestEdge(node1));
            //node3.Add(new TestEdge(node4));
            //node4.Add(new TestEdge(node2));
            //node4.Add(new TestEdge(node3));

            //TestGraph graph = new TestGraph();
            //graph.Add(node1);
            //graph.Add(node2);
            //graph.Add(node3);
            //graph.Add(node4);

            //TestNode source = node1;
            //TestNode destination = node4;
            //IList<string> path = AStarAlgorithm.Calculate(new TestPathfinderComponent(), source, destination).Select(x => x.ToString()).ToList();
            //Assert.IsTrue(path.Last().Equals(destination.ToString()));
        }
    }
}