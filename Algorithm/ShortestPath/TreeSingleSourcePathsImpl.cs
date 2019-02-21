using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

using Algorithm.Graph;

namespace Algorithm.ShortestPath
{

    /**
     * An implementation of {@link SingleSourcePaths} which uses linear space.
     * 
     * <p>
     * This implementation uses the traditional representation of maintaining for each vertex the
     * predecessor in the shortest path tree. In order to keep space to linear, the paths are recomputed
     * in each invocation of the {@link #getPath(Object)} method. The complexity of
     * {@link #getPath(Object)} is linear to the number of edges of the path while the complexity of
     * {@link #getWeight(Object)} is O(1).
     * 
     * @author Dimitrios Michail
     *
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     */
    public class TreeSingleSourcePathsImpl<V, E> : SingleSourcePaths<V, E>
    {
        /**
         * The graph
         */
        protected Graph<V, E> g;

        /**
         * The source vertex
         */
        protected V source;

        /**
         * A map which keeps for each target vertex the predecessor edge and the total length of the
         * shortest path.
         */
        protected Dictionary<V, KeyValuePair<Double, E>> map;

        /**
         * Construct a new instance.
         * 
         * @param g the graph
         * @param source the source vertex
         * @param distanceAndPredecessorMap a map which contains for each vertex the distance and the
         *        last edge that was used to discover the vertex. The map does not need to contain any
         *        entry for the source vertex. In case it does contain the predecessor at the source
         *        vertex must be null.
         */
        public TreeSingleSourcePathsImpl( Graph<V, E> g, V source, Dictionary<V, KeyValuePair<Double, E>> distanceAndPredecessorMap)
        {
            Contract.Requires(g != null);
            Contract.Requires(source != null);
            Contract.Requires(distanceAndPredecessorMap != null);

            this.g =g;
            this.source = source;
            this.map = distanceAndPredecessorMap;
        }

        /**
         * {@inheritDoc}
         */
        public Graph<V, E> getGraph()
        {
            return g;
        }

        /**
         * {@inheritDoc}
         */
        public V getSourceVertex()
        {
            return source;
        }

        /**
         * {@inheritDoc}
         */
        public double getWeight(V targetVertex)
        {
            KeyValuePair<Double, E> p;
            bool find = map.TryGetValue(targetVertex,out p);
            if (!find)
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
                return p.Key;
            }
        }

        /**
         * {@inheritDoc}
         */
        public GraphPath<V, E> getPath(V targetVertex)
        {
            if (source.Equals(targetVertex))
            {
                return GraphWalk<V,E>.singletonWalk(g, source, 0d);
            }

            List<E> edgeList = new List<E>();

            V cur = targetVertex;
            KeyValuePair<Double, E> p;
            bool find  = map.TryGetValue(cur,out p);
            if (!find || p.Key.Equals(Double.PositiveInfinity))
            {
                return null;
            }

            double weight = 0d;
            while (find && !p.Equals(source))
            {
                E e = p.Value;
                if (e == null)
                {
                    break;
                }
                edgeList.Insert(0,e);
                weight += g.getEdgeWeight(e);
                cur = Graphs.getOppositeVertex(g, e, cur);
                find = map.TryGetValue(cur,out p);
            }

            return new GraphWalk<V,E>(g, source, targetVertex, null, edgeList, weight);
        }

    }
}

