using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Algorithm.Collections;
using Algorithm.Graph;

namespace Algorithm.Specifics
{

    /**
     * Fast implementation of DirectedSpecifics. This class uses additional data structures to improve
     * the performance of methods which depend on edge retrievals, e.g. getEdge(V u, V v),
     * containsEdge(V u, V v),addEdge(V u, V v). A disadvantage is an increase in memory consumption. If
     * memory utilization is an issue, use a {@link DirectedSpecifics} instead.
     *
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     *
     * @author Joris Kinable
     */
    public class FastLookupDirectedSpecifics<V, E> : DirectedSpecifics<V, E>
    {
        /*
         * Maps a pair of vertices <u,v> to a set of edges {(u,v)}. In case of a multigraph, all edges
         * which touch both u,v are included in the set
         */
        protected Dictionary<KeyValuePair<V, V>, ArrayUnenforcedSet<E>> touchingVerticesToEdgeMap;

        /**
         * Construct a new fast lookup directed specifics.
         * 
         * @param abstractBaseGraph the graph for which these specifics are for
         */
        public FastLookupDirectedSpecifics(AbstractBaseGraph<V, E> abstractBaseGraph)
            : this(abstractBaseGraph, new Dictionary<V, DirectedEdgeContainer<V, E>>(), new ArrayUnenforcedSetEdgeSetFactory<V, E>())
        {
        }

        /**
         * Construct a new fast lookup directed specifics.
         * 
         * @param abstractBaseGraph the graph for which these specifics are for
         * @param vertexMap map for the storage of vertex edge sets
         */
        public FastLookupDirectedSpecifics(
            AbstractBaseGraph<V, E> abstractBaseGraph, Dictionary<V, DirectedEdgeContainer<V, E>> vertexMap)
            : this(abstractBaseGraph, vertexMap, new ArrayUnenforcedSetEdgeSetFactory<V, E>())
        {
        }

        /**
         * Construct a new fast lookup directed specifics.
         * 
         * @param abstractBaseGraph the graph for which these specifics are for
         * @param vertexMap map for the storage of vertex edge sets
         * @param edgeSetFactory factory for the creation of vertex edge sets
         */
        public FastLookupDirectedSpecifics(
            AbstractBaseGraph<V, E> abstractBaseGraph, Dictionary<V, DirectedEdgeContainer<V, E>> vertexMap,
            EdgeSetFactory<V, E> edgeSetFactory)
                : base(abstractBaseGraph, vertexMap, edgeSetFactory)
        {
            this.touchingVerticesToEdgeMap = new Dictionary<KeyValuePair<V, V>, ArrayUnenforcedSet<E>>();
        }

        public override HashSet<E> getAllEdges(V sourceVertex, V targetVertex)
        {
            if (abstractBaseGraph.containsVertex(sourceVertex)
                && abstractBaseGraph.containsVertex(targetVertex))
            {
                List<E> edges = touchingVerticesToEdgeMap[new KeyValuePair<V, V>(sourceVertex, targetVertex)];
                return edges == null ? new HashSet<E>() : new HashSet<E>(edges);
            }
            else
            {
                return null;
            }
        }

        public override E getEdge(V sourceVertex, V targetVertex)
        {
            List<E> edges = touchingVerticesToEdgeMap[new KeyValuePair<V, V>(sourceVertex, targetVertex)];
            if (edges == null || edges.Count == 0)
                return default(E);
            else
                return edges[0];
        }

        public override void addEdgeToTouchingVertices(E e)
        {
            V source = abstractBaseGraph.getEdgeSource(e);
            V target = abstractBaseGraph.getEdgeTarget(e);

            getEdgeContainer(source).addOutgoingEdge(e);
            getEdgeContainer(target).addIncomingEdge(e);

            KeyValuePair<V, V> vertexPair = new KeyValuePair<V, V>(source, target);
            ArrayUnenforcedSet<E> edgeSet = touchingVerticesToEdgeMap[vertexPair];
            if (edgeSet != null)
                edgeSet.Add(e);
            else
            {
                edgeSet = new ArrayUnenforcedSet<E>();
                edgeSet.Add(e);
                touchingVerticesToEdgeMap[vertexPair] = edgeSet;
            }
        }

        public override void removeEdgeFromTouchingVertices(E e)
        {
            V source = abstractBaseGraph.getEdgeSource(e);
            V target = abstractBaseGraph.getEdgeTarget(e);

            getEdgeContainer(source).removeOutgoingEdge(e);
            getEdgeContainer(target).removeIncomingEdge(e);

            // Remove the edge from the touchingVerticesToEdgeMap. If there are no more remaining edges
            // for a pair
            // of touching vertices, remove the pair from the map.
            KeyValuePair<V, V> vertexPair = new KeyValuePair<V, V>(source, target);
            ArrayUnenforcedSet<E> edgeSet = touchingVerticesToEdgeMap[vertexPair];
            if (edgeSet != null)
            {
                edgeSet.Remove(e);
                if (edgeSet.Count == 0)
                    touchingVerticesToEdgeMap.Remove(vertexPair);
            }
        }

    }

}
