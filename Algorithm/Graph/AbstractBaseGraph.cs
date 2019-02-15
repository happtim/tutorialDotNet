
using System;
using System.Diagnostics.Contracts;
using System.Collections.Generic;

using Algorithm.Specifics;

namespace Algorithm.Graph
{

    /**
     * The most general implementation of the {@link org.jgrapht.Graph} interface. Its subclasses add
     * various restrictions to get more specific graphs. The decision whether it is directed or
     * undirected is decided at construction time and cannot be later modified (see constructor for
     * details).
     *
     * <p>
     * This graph implementation guarantees deterministic vertex and edge set ordering (via
     * {@link LinkedHashMap} and {@link LinkedHashSet}).
     * </p>
     *
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     *
     * @author Barak Naveh
     * @since Jul 24, 2003
     */
    public abstract class AbstractBaseGraph<V, E> : AbstractGraph<V, E>
    {
        //private static long serialVersionUID = 4811000483921413364L;

        private static String LOOPS_NOT_ALLOWED = "loops not allowed";
        private static String GRAPH_SPECIFICS_MUST_NOT_BE_NULL = "Graph specifics must not be null";

        private EdgeFactory<V, E> edgeFactory;
        private HashSet<V> unmodifiableVertexSet = null;

        private Specifics<V, E> specifics;
        private IntrusiveEdgesSpecifics<V, E> intrusiveEdgesSpecifics;

        private bool directed;
        private bool weighted;
        private bool allowingMultipleEdges;
        private bool allowingLoops;

        /**
         * Construct a new graph. The graph can either be directed or undirected, depending on the
         * specified edge factory.
         *
         * @param ef the edge factory of the new graph.
         * @param directed if true the graph will be directed, otherwise undirected
         * @param allowMultipleEdges whether to allow multiple edges or not.
         * @param allowLoops whether to allow edges that are self-loops or not.
         * @param weighted whether the graph is weighted, i.e. the edges support a weight attribute
         *
         * @throws NullPointerException if the specified edge factory is <code>
         * null</code>.
         */
        protected AbstractBaseGraph(
            EdgeFactory<V, E> ef, bool directed, bool allowMultipleEdges, bool allowLoops,
            bool weighted)
        {
            Contract.Requires(ef != null);

            this.edgeFactory = ef;
            this.allowingLoops = allowLoops;
            this.allowingMultipleEdges = allowMultipleEdges;
            this.directed = directed;
            this.weighted = weighted;

            this.specifics = createSpecifics(directed);
            Contract.Requires(specifics != null);

            this.intrusiveEdgesSpecifics = createIntrusiveEdgesSpecifics(weighted);
            Contract.Requires(intrusiveEdgesSpecifics != null);
        }

        /**
         * {@inheritDoc}
         */
        public override HashSet<E> getAllEdges(V sourceVertex, V targetVertex)
        {
            return specifics.getAllEdges(sourceVertex, targetVertex);
        }

        /**
         * Returns <code>true</code> if and only if self-loops are allowed in this graph. A self loop is
         * an edge that its source and target vertices are the same.
         *
         * @return <code>true</code> if and only if graph loops are allowed.
         */
        public bool isAllowingLoops()
        {
            return allowingLoops;
        }

        /**
         * Returns <code>true</code> if and only if multiple edges are allowed in this graph. The
         * meaning of multiple edges is that there can be many edges going from vertex v1 to vertex v2.
         *
         * @return <code>true</code> if and only if multiple edges are allowed.
         */
        public bool isAllowingMultipleEdges()
        {
            return allowingMultipleEdges;
        }

        /**
         * Returns <code>true</code> if and only if the graph supports edge weights.
         *
         * @return <code>true</code> if the graph supports edge weights, <code>false</code> otherwise.
         */
        public bool isWeighted()
        {
            return weighted;
        }

        /**
         * Returns <code>true</code> if the graph is directed, false if undirected.
         *
         * @return <code>true</code> if the graph is directed, false if undirected.
         */
        public bool isDirected()
        {
            return directed;
        }

        /**
         * {@inheritDoc}
         */
        public override E getEdge(V sourceVertex, V targetVertex)
        {
            return specifics.getEdge(sourceVertex, targetVertex);
        }

        /**
         * {@inheritDoc}
         */
        public override EdgeFactory<V, E> getEdgeFactory()
        {
            return edgeFactory;
        }

        /**
         * {@inheritDoc}
         */
        public override E addEdge(V sourceVertex, V targetVertex)
        {
            assertVertexExist(sourceVertex);
            assertVertexExist(targetVertex);

            if (!allowingMultipleEdges && containsEdge(sourceVertex, targetVertex))
            {
                return default(E);
            }

            if (!allowingLoops && sourceVertex.Equals(targetVertex))
            {
                throw new ArgumentException(LOOPS_NOT_ALLOWED);
            }

            E e = edgeFactory.createEdge(sourceVertex, targetVertex);

            if (containsEdge(e))
            { // this restriction should stay!
                return default(E);
            }
            else
            {
                intrusiveEdgesSpecifics.add(e, sourceVertex, targetVertex);
                specifics.addEdgeToTouchingVertices(e);
                return e;
            }
        }

        /**
         * {@inheritDoc}
         */
        public override bool addEdge(V sourceVertex, V targetVertex, E e)
        {
            if (e == null)
            {
                throw new NullReferenceException();
            }
            else if (containsEdge(e))
            {
                return false;
            }

            assertVertexExist(sourceVertex);
            assertVertexExist(targetVertex);

            if (!allowingMultipleEdges && containsEdge(sourceVertex, targetVertex))
            {
                return false;
            }

            if (!allowingLoops && sourceVertex.Equals(targetVertex))
            {
                throw new ArgumentException(LOOPS_NOT_ALLOWED);
            }

            intrusiveEdgesSpecifics.add(e, sourceVertex, targetVertex);
            specifics.addEdgeToTouchingVertices(e);

            return true;
        }

        /**
         * {@inheritDoc}
         */
        public override bool addVertex(V v)
        {
            if (v == null)
            {
                throw new NullReferenceException();
            }
            else if (containsVertex(v))
            {
                return false;
            }
            else
            {
                specifics.addVertex(v);

                return true;
            }
        }

        /**
         * {@inheritDoc}
         */
        public override V getEdgeSource(E e)
        {
            return intrusiveEdgesSpecifics.getEdgeSource(e);
        }

        /**
         * {@inheritDoc}
         */
        public override V getEdgeTarget(E e)
        {
            return intrusiveEdgesSpecifics.getEdgeTarget(e);
        }

        /**
         * Returns a shallow copy of this graph instance. Neither edges nor vertices are cloned.
         *
         * @return a shallow copy of this set.
         *
         * @throws RuntimeException in case the clone is not supported
         *
         * @see java.lang.Object#clone()
         */
         /*
        public override Object Clone()
        {
            try
            {
                AbstractBaseGraph<V, E> newGraph = TypeUtil.uncheckedCast(super.clone(), null);

                newGraph.edgeFactory = this.edgeFactory;
                newGraph.unmodifiableVertexSet = null;

                // NOTE: it's important for this to happen in an object
                // method so that the new inner class instance gets associated with
                // the right outer class instance
                newGraph.specifics = newGraph.createSpecifics(this.directed);
                newGraph.intrusiveEdgesSpecifics =
                    newGraph.createIntrusiveEdgesSpecifics(this.weighted);

                Graphs.addGraph(newGraph, this);

                return newGraph;
            }
            catch (CloneNotSupportedException e)
            {
                e.printStackTrace();
                throw new RuntimeException();
            }
        }
        */

        /**
         * {@inheritDoc}
         */
        public override bool containsEdge(E e)
        {
            return intrusiveEdgesSpecifics.containsEdge(e);
        }

        /**
         * {@inheritDoc}
         */
        public override bool containsVertex(V v)
        {
            return specifics.getVertexSet().Contains(v);
        }

        /**
         * {@inheritDoc}
         */
        public override int degreeOf(V vertex)
        {
            return specifics.degreeOf(vertex);
        }

        /**
         * {@inheritDoc}
         */
        public override HashSet<E> edgeSet()
        {
            return intrusiveEdgesSpecifics.getEdgeSet();
        }

        /**
         * {@inheritDoc}
         */
        public override HashSet<E> edgesOf(V vertex)
        {
            assertVertexExist(vertex);
            return specifics.edgesOf(vertex);
        }

        /**
         * {@inheritDoc}
         */
        public override int inDegreeOf(V vertex)
        {
            assertVertexExist(vertex);
            return specifics.inDegreeOf(vertex);
        }

        /**
         * {@inheritDoc}
         */
        public override HashSet<E> incomingEdgesOf(V vertex)
        {
            assertVertexExist(vertex);
            return specifics.incomingEdgesOf(vertex);
        }

        /**
         * {@inheritDoc}
         */
        public override int outDegreeOf(V vertex)
        {
            assertVertexExist(vertex);
            return specifics.outDegreeOf(vertex);
        }

        /**
         * {@inheritDoc}
         */
        public override HashSet<E> outgoingEdgesOf(V vertex)
        {
            assertVertexExist(vertex);
            return specifics.outgoingEdgesOf(vertex);
        }

        /**
         * {@inheritDoc}
         */
        public override E removeEdge(V sourceVertex, V targetVertex)
        {
            E e = getEdge(sourceVertex, targetVertex);

            if (e != null)
            {
                specifics.removeEdgeFromTouchingVertices(e);
                intrusiveEdgesSpecifics.remove(e);
            }

            return e;
        }

        /**
         * {@inheritDoc}
         */
        public override bool removeEdge(E e)
        {
            if (containsEdge(e))
            {
                specifics.removeEdgeFromTouchingVertices(e);
                intrusiveEdgesSpecifics.remove(e);
                return true;
            }
            else
            {
                return false;
            }
        }

        /**
         * {@inheritDoc}
         */
        public override bool removeVertex(V v)
        {
            if (containsVertex(v))
            {
                HashSet<E> touchingEdgesList = edgesOf(v);

                // cannot iterate over list - will cause
                // ConcurrentModificationException
                removeAllEdges(new List<E>(touchingEdgesList));

                specifics.getVertexSet().Remove(v); // remove the vertex itself

                return true;
            }
            else
            {
                return false;
            }
        }

        /**
         * {@inheritDoc}
         */
        public override HashSet<V> vertexSet()
        {
            if (unmodifiableVertexSet == null)
            {
                unmodifiableVertexSet = new HashSet<V>(specifics.getVertexSet());
            }

            return unmodifiableVertexSet;
        }

        /**
         * {@inheritDoc}
         */
        public override double getEdgeWeight(E e)
        {
            if (e == null)
            {
                throw new NullReferenceException();
            }
            return intrusiveEdgesSpecifics.getEdgeWeight(e);
        }

        /**
         * Set an edge weight.
         * 
         * @param e the edge
         * @param weight the weight
         * @throws UnsupportedOperationException if the graph is not weighted
         */
        public override void setEdgeWeight(E e, double weight)
        {
            if (e == null)
            {
                throw new NullReferenceException();
            }
            intrusiveEdgesSpecifics.setEdgeWeight(e, weight);
        }

        /**
         * {@inheritDoc}
         */
        public override GraphType getType()
        {
            if (directed)
            {
                return new DefaultGraphType.Builder()
                    .Directed().Weighted(weighted).AllowMultipleEdges(allowingMultipleEdges)
                    .AllowSelfLoops(allowingLoops).build();
            }
            else
            {
                return new DefaultGraphType.Builder()
                    .Undirected().Weighted(weighted).AllowMultipleEdges(allowingMultipleEdges)
                    .AllowSelfLoops(allowingLoops).build();
            }
        }

        /**
         * Create the specifics for this graph. Subclasses can override this method in order to adjust
         * the specifics and thus the space-time tradeoffs of the graph implementation.
         * 
         * @param directed if true the specifics should adjust the behavior to a directed graph
         *        otherwise undirected
         * @return the specifics used by this graph
         */
        protected Specifics<V, E> createSpecifics(bool directed)
        {
            if (directed)
            {
                return new FastLookupDirectedSpecifics<V,E>(this);
            }
            else
            {
                throw new NotImplementedException();
                //return new FastLookupUndirectedSpecifics<>(this);
            }
        }

        /**
         * Create the specifics for the edges set of the graph.
         * 
         * @param weighted if true the specifics should support weighted edges
         * @return the specifics used for the edge set of this graph
         */
        protected IntrusiveEdgesSpecifics<V, E> createIntrusiveEdgesSpecifics(bool weighted)
        {
            if (weighted)
            {
                return new WeightedIntrusiveEdgesSpecifics<V, E>();
            }
            else
            {
                throw new NotImplementedException();
                //return new UniformIntrusiveEdgesSpecifics<V, E>();
            }
        }

    }
    // End AbstractBaseGraph.java
}

