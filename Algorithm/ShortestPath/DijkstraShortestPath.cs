
using System;
using System.Linq;
using System.Collections.Generic;


using Algorithm.Graph;

namespace Algorithm.ShortestPath
{

    /**
     * An implementation of <a href="http://mathworld.wolfram.com/DijkstrasAlgorithm.html">Dijkstra's
     * shortest path algorithm</a> using a Fibonacci heap.
     *
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     *
     * @author John V. Sichi
     */
    public class DijkstraShortestPath<V, E> : BaseShortestPathAlgorithm<V, E>
    {
        private  double radius;

        /**
         * Constructs a new instance of the algorithm for a given graph.
         * 
         * @param graph the graph
         */
        public DijkstraShortestPath(Graph<V, E> graph)
            : this(graph, double.PositiveInfinity)
        { }

        /**
         * Constructs a new instance of the algorithm for a given graph.
         *
         * @param graph the graph
         * @param radius limit on path length, or Double.POSITIVE_INFINITY for unbounded search
         */
        public DijkstraShortestPath(Graph<V, E> graph, double radius): base(graph)
        {
            if (radius < 0.0)
            {
                throw new ArgumentException("Radius must be non-negative");
            }
            this.radius = radius;
        }

        /**
         * {@inheritDoc}
         */
        public override GraphPath<V, E> getPath(V source, V sink)
        {
            if (!graph.containsVertex(source))
            {
                throw new ArgumentException(GRAPH_MUST_CONTAIN_THE_SOURCE_VERTEX);
            }
            if (!graph.containsVertex(sink))
            {
                throw new ArgumentException(GRAPH_MUST_CONTAIN_THE_SINK_VERTEX);
            }
            if (source.Equals(sink))
            {
                return createEmptyPath(source, sink);
            }

            DijkstraClosestFirstIterator<V, E> it =
                new DijkstraClosestFirstIterator<V,E>(graph, source, radius);

            while (it.hasNext())
            {
                V vertex = it.next();
                if (vertex.Equals(sink))
                {
                    break;
                }
            }

            return it.getPaths().getPath(sink);
        }

        /**
         * {@inheritDoc}
         *
         * Note that in the case of Dijkstra's algorithm it is more efficient to compute all
         * single-source shortest paths using this method than repeatedly invoking
         * {@link #getPath(Object, Object)} for the same source but different sink vertex.
         */
        public override SingleSourcePaths<V, E> getPaths(V source)
        {
            if (!graph.containsVertex(source))
            {
                throw new ArgumentException(GRAPH_MUST_CONTAIN_THE_SOURCE_VERTEX);
            }

            DijkstraClosestFirstIterator<V, E> it =
                new DijkstraClosestFirstIterator<V,E>(graph, source, radius);

            while (it.hasNext())
            {
                it.next();
            }

            return it.getPaths();
        }

        /**
         * Find a path between two vertices. For a more advanced search (e.g. limited by radius), use
         * the constructor instead.
         * 
         * @param graph the graph to be searched
         * @param source the vertex at which the path should start
         * @param sink the vertex at which the path should end
         * 
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return a shortest path, or null if no path exists
         */
        public static GraphPath<V, E> findPathBetween(Graph<V, E> graph, V source, V sink)
        {
            return new DijkstraShortestPath<V,E>(graph).getPath(source, sink);
        }

    }
}

