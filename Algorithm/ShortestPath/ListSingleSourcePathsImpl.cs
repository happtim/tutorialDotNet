using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

using Algorithm.Graph;

namespace Algorithm.ShortestPath
{

    /**
     * An implementation of {@link SingleSourcePaths} which stores one path per vertex.
     * 
     * <p>
     * This is an explicit representation which stores all paths. For a more compact representation see
     * {@link TreeSingleSourcePathsImpl}.
     * 
     * @author Dimitrios Michail
     *
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     */
    public class ListSingleSourcePathsImpl<V, E> : SingleSourcePaths<V, E>
    {
        /**
         * The graph
         */
        protected Graph<V, E> graph;

        /**
         * The source vertex of all paths
         */
        protected V source;

        /**
         * One path per vertex
         */
        protected Dictionary<V, GraphPath<V, E>> paths;

        /**
         * Construct a new instance.
         * 
         * @param graph the graph
         * @param source the source vertex
         * @param paths one path per target vertex
         */
        public ListSingleSourcePathsImpl(Graph<V, E> graph, V source, Dictionary<V, GraphPath<V, E>> paths)
        {

            Contract.Requires(graph != null);
            Contract.Requires(source!= null);
            Contract.Requires(paths!= null);

            this.graph = graph;
            this.source = source;
            this.paths = paths;

//            this.graph = Objects.requireNonNull(graph, "Graph is null");
//            this.source = Objects.requireNonNull(source, "Source vertex is null");
//            this.paths = Objects.requireNonNull(paths, "Paths are null");
        }

        /**
         * {@inheritDoc}
         */
        public  Graph<V, E> getGraph()
        {
            return graph;
        }

        /**
         * {@inheritDoc}
         */
        public  V getSourceVertex()
        {
            return source;
        }

        /**
         * {@inheritDoc}
         */
        public  double getWeight(V targetVertex)
        {
            GraphPath<V, E> p = paths[targetVertex];
            if (p == null)
            {
                if (source.Equals(targetVertex))
                {
                    return 0d;
                }
                else
                {
                    return Double.PositiveInfinity;
                }
            }
            else
            {
                return p.getWeight();
            }
        }

        /**
         * {@inheritDoc}
         */
        public  GraphPath<V, E> getPath(V targetVertex)
        {
            GraphPath<V, E> p = paths[targetVertex];
            if (p == null)
            {
                if (source.Equals(targetVertex))
                {
                    return GraphWalk<V,E>.singletonWalk(graph, source, 0d);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return p;
            }
        }

    }
}

