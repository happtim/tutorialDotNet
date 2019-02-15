using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

using Algorithm.Graph;

namespace Algorithm.ShortestPath
{

    /**
     * A base implementation of the shortest path interface.
     *
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     *
     * @author Dimitrios Michail
     */
    public abstract class BaseShortestPathAlgorithm<V, E> : ShortestPathAlgorithm<V, E>
    {
        /**
         * Error message for reporting the existence of a negative-weight cycle.
         */
        public static string GRAPH_CONTAINS_A_NEGATIVE_WEIGHT_CYCLE = "Graph contains a negative-weight cycle";
        /**
         * Error message for reporting that a source vertex is missing.
         */
        public static string GRAPH_MUST_CONTAIN_THE_SOURCE_VERTEX = "Graph must contain the source vertex!";
        /**
         * Error message for reporting that a sink vertex is missing.
         */
        public static string GRAPH_MUST_CONTAIN_THE_SINK_VERTEX = "Graph must contain the sink vertex!";

        /**
         * The underlying graph.
         */
        protected Graph<V, E> graph;

        /**
         * Constructs a new instance of the algorithm for a given graph.
         * 
         * @param graph the graph
         */
        public BaseShortestPathAlgorithm(Graph<V, E> graph)
        {
            Contract.Requires(graph != null);
            this.graph = graph;
        }

        /**
         * {@inheritDoc}
         */
        public virtual SingleSourcePaths<V, E> getPaths(V source)
        {
            if (!graph.containsVertex(source))
            {
                throw new ArgumentException("graph must contain the source vertex");
            }

            Dictionary<V, GraphPath<V, E>> paths = new Dictionary<V,GraphPath<V,E>>();
            foreach(V v in graph.vertexSet())
            {
                paths.Add(v, getPath(source, v));
            }
            return new ListSingleSourcePathsImpl<V,E>(graph, source, paths);
        }

        /**
         * {@inheritDoc}
         */
        public double getPathWeight(V source, V sink)
        {
            GraphPath<V, E> p = getPath(source, sink);
            if (p == null)
            {
                return Double.PositiveInfinity;
            }
            else
            {
                return p.getWeight();
            }
        }

        /**
         * Create an empty path. Returns null if the source vertex is different than the target vertex.
         * 
         * @param source the source vertex
         * @param sink the sink vertex
         * @return an empty path or null null if the source vertex is different than the target vertex
         */
        protected GraphPath<V, E> createEmptyPath(V source, V sink)
        {
            if (source.Equals(sink))
            {
                return GraphWalk<V,E>.singletonWalk(graph, source, 0d);
            }
            else
            {
                return null;
            }
        }

        public abstract GraphPath<V, E> getPath(V source, V sink);
    }
}

