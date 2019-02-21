using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Algorithm.ShortestPath;
using Algorithm.Graph;

namespace Algorithm.Test
{
    [TestClass]
    public class DijkstraShortestPathTest :ShortestPathTestCase {

        [TestMethod]
        public void testConstructor() {
            GraphPath<String, DefaultWeightedEdge> path;
            Graph<String, DefaultWeightedEdge> g = create();

            path = new DijkstraShortestPath<string,DefaultWeightedEdge>(g, Double.PositiveInfinity).getPath(V1, V5);
            Assert.AreEqual(new List<DefaultWeightedEdge>() { e13, e12, e24 }, path.getEdgeList());
            //assertEquals(Arrays.asList(e13, e12, e24), path.getEdgeList());
            Assert.AreEqual(10.0, path.getWeight(), 0);
//            assertEquals(10.0, path.getWeight(), 0);

            path = new DijkstraShortestPath<string,DefaultWeightedEdge>(g, 7.0).getPath(V3, V4);
            Assert.AreEqual(null, path);
//            assertNull(path);
        }

        protected override List<DefaultWeightedEdge> findPathBetween(Graph<string, DefaultWeightedEdge> g, string src, string dest)
        {
            return new DijkstraShortestPath<string,DefaultWeightedEdge>(g).getPath(src, dest).getEdgeList();
        }
    }
}
