using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Algorithm.Graph;

namespace Algorithm.Test
{

    /**
     * .
     *
     * @author John V. Sichi
     */
    public abstract class ShortestPathTestCase
    {
        // ~ Static fields/initializers ---------------------------------------------

        public static String V1 = "v1";
        public static String V2 = "v2";
        public static String V3 = "v3";
        public static String V4 = "v4";
        public static String V5 = "v5";

        // ~ Instance fields --------------------------------------------------------

        public DefaultWeightedEdge e12;
        public DefaultWeightedEdge e13;
        public DefaultWeightedEdge e15;
        public DefaultWeightedEdge e24;
        public DefaultWeightedEdge e34;
        public DefaultWeightedEdge e45;

        // ~ Methods ----------------------------------------------------------------

        /**
         * .
         */
        public void testPathBetween()
        {
            List<DefaultWeightedEdge> path;
            Graph<String, DefaultWeightedEdge> g = create();

            path = findPathBetween(g, V1, V2);
            //assertEquals(Arrays.asList(new DefaultWeightedEdge[] { e12 }), path);

            path = findPathBetween(g, V1, V4);
            //assertEquals(Arrays.asList(new DefaultWeightedEdge[] { e12, e24 }), path);

            path = findPathBetween(g, V1, V5);
            //assertEquals(Arrays.asList(new DefaultWeightedEdge[] { e12, e24, e45 }), path);

            path = findPathBetween(g, V3, V4);
            //assertEquals(Arrays.asList(new DefaultWeightedEdge[] { e13, e12, e24 }), path);
        }

        protected abstract List<DefaultWeightedEdge> findPathBetween(Graph<String, DefaultWeightedEdge> g, String src, String dest);

        protected Graph<String, DefaultWeightedEdge> create()
        {
            return createWithBias(true);
        }

        protected Graph<String, DefaultWeightedEdge> createWithBias(bool negate)
        {
            Graph<String, DefaultWeightedEdge> g;
            double bias = 1;
            if (negate)
            {
                // negative-weight edges are being tested, so only a directed graph
                // makes sense
                g = new SimpleDirectedWeightedGraph<string, DefaultWeightedEdge>(typeof(DefaultWeightedEdge));
                bias = 1;
            }
            else
            {
                // by default, use an undirected graph
                g = new SimpleWeightedGraph<string, DefaultWeightedEdge>(typeof(DefaultWeightedEdge));
            }

            g.addVertex(V1);
            g.addVertex(V2);
            g.addVertex(V3);
            g.addVertex(V4);
            g.addVertex(V5);

            e12 = Graphs.addEdge(g, V1, V2, bias * 2);

            e13 = Graphs.addEdge(g, V1, V3, bias * 3);

            e24 = Graphs.addEdge(g, V2, V4, bias * 5);

            e34 = Graphs.addEdge(g, V3, V4, bias * 20);

            e45 = Graphs.addEdge(g, V4, V5, bias * 5);

            e15 = Graphs.addEdge(g, V1, V5, bias * 100);

            return g;
        }
    }

    // End ShortestPathTestCase.java

}
