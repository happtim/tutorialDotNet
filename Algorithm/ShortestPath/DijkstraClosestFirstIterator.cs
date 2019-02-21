using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

using Algorithm.Collections;
using Algorithm.Graph;

namespace Algorithm.ShortestPath
{

    /**
     * A light-weight version of the closest-first iterator for a directed or undirected graphs. For
     * this iterator to work correctly the graph must not be modified during iteration. Currently there
     * are no means to ensure that, nor to fail-fast. The results of such modifications are undefined.
     * 
     * <p>
     * The metric for <i>closest</i> here is the weighted path length from a start vertex, i.e.
     * Graph.getEdgeWeight(Edge) is summed to calculate path length. Negative edge weights will result
     * in an IllegalArgumentException. Optionally, path length may be bounded by a finite radius.
     * 
     * <p>
     * NOTE: This is an internal iterator for use in shortest paths algorithms. For an iterator that is
     * suitable to return to the users see {@link org.jgrapht.traverse.ClosestFirstIterator}. This
     * implementation is must faster since it does not support graph traversal listeners nor
     * disconnected components.
     *
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     *
     * @author John V. Sichi
     * @author Dimitrios Michail
     */
    class DijkstraClosestFirstIterator<V, E> : IEnumerable<V> 
    {
        private  Graph<V, E> graph;
        private  V source;
        private  double radius;
        private  FibonacciHeap<QueueEntry> heap;
        private  Dictionary<V, FibonacciHeapNode<QueueEntry>> seen;

        /**
         * Creates a new iterator for the specified graph. Iteration will start at the specified start
         * vertex and will be limited to the connected component that includes that vertex.
         * 
         * @param graph the graph to be iterated.
         * @param source the source vertex
         */
        public DijkstraClosestFirstIterator(Graph<V, E> graph, V source):
            this(graph,source,Double.PositiveInfinity)
        {
        }

        /**
         * Creates a new radius-bounded iterator for the specified graph. Iteration will start at the
         * specified start vertex and will be limited to the subset of the connected component which
         * includes that vertex and is reachable via paths of weighted length less than or equal to the
         * specified radius.
         *
         * @param graph the graph
         * @param source the source vertex
         * @param radius limit on weighted path length, or Double.POSITIVE_INFINITY for unbounded search
         */
        public DijkstraClosestFirstIterator(Graph<V, E> graph, V source, double radius)
        {
            Contract.Requires(graph != null);
            Contract.Requires(source != null);
            this.graph = graph;
            this.source  = source;
            //this.graph = Objects.requireNonNull(graph, "Graph cannot be null");
            //this.source = Objects.requireNonNull(source, "Sourve vertex cannot be null");
            if (radius < 0.0)
            {
                throw new ArgumentException("Radius must be non-negative");
            }
            this.radius = radius;
            this.heap = new FibonacciHeap<QueueEntry>();
            this.seen = new Dictionary<V, FibonacciHeapNode<QueueEntry>>();

            // initialize with source vertex
            updateDistance(source, default(E), 0d);
        }

        public bool hasNext()
        {
            if (heap.isEmpty())
            {
                return false;
            }
            FibonacciHeapNode<QueueEntry> vNode = heap.min();
            double vDistance = vNode.getKey();
            if (radius < vDistance)
            {
                heap.clear();
                return false;
            }
            return true;
        }

        /**
         * {@inheritDoc}
         */
        public V next()
        {
            if (!hasNext())
            {
                throw new Exception("NoSuchElementException");
            }

            // settle next node
            FibonacciHeapNode<QueueEntry> vNode = heap.removeMin();
            V v = vNode.getData().v;
            double vDistance = vNode.getKey();

            // relax edges
            foreach (E e in graph.outgoingEdgesOf(v))
            {
                V u = Graphs.getOppositeVertex(graph, e, v);
                double eWeight = graph.getEdgeWeight(e);
                if (eWeight < 0.0)
                {
                    throw new ArgumentException("Negative edge weight not allowed");
                }
                updateDistance(u, e, vDistance + eWeight);
            }

            return v;
        }

        /**
         * Return the paths computed by this iterator. Only the paths to vertices which are already
         * returned by the iterator will be shortest paths. Additional paths to vertices which are not
         * yet returned (settled) by the iterator might be included with the following properties: the
         * distance will be an upper bound on the actual shortest path and the distance will be inside
         * the radius of the search.
         * 
         * @return the single source paths
         */
        public SingleSourcePaths<V, E> getPaths()
        {
            return new TreeSingleSourcePathsImpl<V,E>(graph, source, getDistanceAndPredecessorMap());
        }

        /**
         * Return all paths using the traditional representation of the shortest path tree, which stores
         * for each vertex (a) the distance of the path from the source vertex and (b) the last edge
         * used to reach the vertex from the source vertex.
         * 
         * Only the paths to vertices which are already returned by the iterator will be shortest paths.
         * Additional paths to vertices which are not yet returned (settled) by the iterator might be
         * included with the following properties: the distance will be an upper bound on the actual
         * shortest path and the distance will be inside the radius of the search.
         * 
         * @return a distance and predecessor map
         */
        public Dictionary<V, KeyValuePair<Double, E>> getDistanceAndPredecessorMap()
        {
            Dictionary<V, KeyValuePair<Double, E>> distanceAndPredecessorMap = new Dictionary<V, KeyValuePair<double, E>>();

            foreach (FibonacciHeapNode<QueueEntry> vNode in seen.Values)
            {
                double vDistance = vNode.getKey();
                if (radius < vDistance)
                {
                    continue;
                }
                V v = vNode.getData().v;
                distanceAndPredecessorMap[v] = new KeyValuePair<Double,E>(vDistance, vNode.getData().e);
            }

            return distanceAndPredecessorMap;
        }

        private void updateDistance(V v, E e, double distance)
        {
            FibonacciHeapNode<QueueEntry> node = null;
            seen.TryGetValue(v,out node);
            if (node == null)
            {
                node = new FibonacciHeapNode<QueueEntry>(new QueueEntry(e, v));
                heap.insert(node, distance);
                seen[v] = node;
            }
            else
            {
                if (distance < node.getKey())
                {
                    heap.decreaseKey(node, distance);
                    node.getData().e = e;
                }
            }
        }

        public IEnumerator<V> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        class QueueEntry
        {
            public E e;
            public V v;

            public QueueEntry(E e, V v)
            {
                this.e = e;
                this.v = v;
            }
        }
    }
}

