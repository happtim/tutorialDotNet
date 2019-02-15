using System;
using System.Collections.Generic;

namespace Algorithm.Graph
{

    /**
     * A collection of utilities to assist with graph manipulation.
     *
     * @author Barak Naveh
     * @since Jul 31, 2003
     */
    public abstract class Graphs
    {
        /**
         * Creates a new edge and adds it to the specified graph similarly to the
         * {@link Graph#addEdge(Object, Object)} method.
         *
         * @param g the graph for which the edge to be added
         * @param sourceVertex source vertex of the edge
         * @param targetVertex target vertex of the edge
         * @param weight weight of the edge
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return The newly created edge if added to the graph, otherwise <code>
         * null</code>.
         *
         * @see Graph#addEdge(Object, Object)
         */
        public static E addEdge<V,E>(Graph<V, E> g, V sourceVertex, V targetVertex, double weight)
        {
            EdgeFactory<V, E> ef = g.getEdgeFactory();
            E e = ef.createEdge(sourceVertex, targetVertex);

            // we first create the edge and set the weight to make sure that
            // listeners will see the correct weight upon addEdge.
            g.setEdgeWeight(e, weight);

            return g.addEdge(sourceVertex, targetVertex, e) ? e : default(E) ;
        }

        /**
         * Adds the specified source and target vertices to the graph, if not already included, and
         * creates a new edge and adds it to the specified graph similarly to the
         * {@link Graph#addEdge(Object, Object)} method.
         *
         * @param g the graph for which the specified edge to be added
         * @param sourceVertex source vertex of the edge
         * @param targetVertex target vertex of the edge
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return The newly created edge if added to the graph, otherwise <code>
         * null</code>.
         */
        public static E addEdgeWithVertices<V,E>(Graph<V, E> g, V sourceVertex, V targetVertex)
        {
            g.addVertex(sourceVertex);
            g.addVertex(targetVertex);

            return g.addEdge(sourceVertex, targetVertex);
        }

        /**
         * Adds the specified edge to the graph, including its vertices if not already included.
         *
         * @param targetGraph the graph for which the specified edge to be added
         * @param sourceGraph the graph in which the specified edge is already present
         * @param edge edge to add
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return <tt>true</tt> if the target graph did not already contain the specified edge.
         */
        public static  bool addEdgeWithVertices<V,E>(Graph<V, E> targetGraph, Graph<V, E> sourceGraph, E edge)
        {
            V sourceVertex = sourceGraph.getEdgeSource(edge);
            V targetVertex = sourceGraph.getEdgeTarget(edge);

            targetGraph.addVertex(sourceVertex);
            targetGraph.addVertex(targetVertex);

            return targetGraph.addEdge(sourceVertex, targetVertex, edge);
        }

        /**
         * Adds the specified source and target vertices to the graph, if not already included, and
         * creates a new weighted edge and adds it to the specified graph similarly to the
         * {@link Graph#addEdge(Object, Object)} method.
         *
         * @param g the graph for which the specified edge to be added
         * @param sourceVertex source vertex of the edge
         * @param targetVertex target vertex of the edge
         * @param weight weight of the edge
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return The newly created edge if added to the graph, otherwise <code>
         * null</code>.
         */
        public static E addEdgeWithVertices<V,E>(Graph<V, E> g, V sourceVertex, V targetVertex, double weight)
        {
            g.addVertex(sourceVertex);
            g.addVertex(targetVertex);

            return addEdge(g, sourceVertex, targetVertex, weight);
        }

        /**
         * Adds all the vertices and all the edges of the specified source graph to the specified
         * destination graph. First all vertices of the source graph are added to the destination graph.
         * Then every edge of the source graph is added to the destination graph. This method returns
         * <code>true</code> if the destination graph has been modified as a result of this operation,
         * otherwise it returns <code>false</code>.
         *
         * <p>
         * The behavior of this operation is undefined if any of the specified graphs is modified while
         * operation is in progress.
         * </p>
         *
         * @param destination the graph to which vertices and edges are added
         * @param source the graph used as source for vertices and edges to add
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return <code>true</code> if and only if the destination graph has been changed as a result
         *         of this operation.
         */
        public static bool addGraph<V,E>(Graph< V,  E> destination, Graph<V, E> source)
        {
            bool modified = addAllVertices(destination, source.vertexSet());
            modified |= addAllEdges(destination, source, source.edgeSet());

            return modified;
        }

        /**
         * Adds all the vertices and all the edges of the specified source digraph to the specified
         * destination digraph, reversing all of the edges. If you want to do this as a linked view of
         * the source graph (rather than by copying to a destination graph), use
         * {@link EdgeReversedGraph} instead.
         *
         * <p>
         * The behavior of this operation is undefined if any of the specified graphs is modified while
         * operation is in progress.
         *
         * @param destination the graph to which vertices and edges are added
         * @param source the graph used as source for vertices and edges to add
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @see EdgeReversedGraph
         */
        public static  void addGraphReversed<V,E>(Graph<V,  E> destination, Graph<V, E> source)
        {
            if (!source.getType().isDirected() || !destination.getType().isDirected())
            {
                throw new ArgumentException("graph must be directed");
            }

            addAllVertices(destination, source.vertexSet());

            foreach (E edge in source.edgeSet())
            {
                destination.addEdge(source.getEdgeTarget(edge), source.getEdgeSource(edge));
            }
        }

        /**
         * Adds a subset of the edges of the specified source graph to the specified destination graph.
         * The behavior of this operation is undefined if either of the graphs is modified while the
         * operation is in progress. {@link #addEdgeWithVertices} is used for the transfer, so source
         * vertexes will be added automatically to the target graph.
         *
         * @param destination the graph to which edges are to be added
         * @param source the graph used as a source for edges to add
         * @param edges the edges to be added
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return <tt>true</tt> if this graph changed as a result of the call
         */
        public static  bool addAllEdges<V,E>( Graph<  V,   E> destination, Graph<V, E> source, ICollection<E> edges)
        {
            bool modified = false;

            foreach (E e in edges)
            {
                V s = source.getEdgeSource(e);
                V t = source.getEdgeTarget(e);
                destination.addVertex(s);
                destination.addVertex(t);
                modified |= destination.addEdge(s, t, e);
            }

            return modified;
        }

        /**
         * Adds all of the specified vertices to the destination graph. The behavior of this operation
         * is undefined if the specified vertex collection is modified while the operation is in
         * progress. This method will invoke the {@link Graph#addVertex(Object)} method.
         *
         * @param destination the graph to which edges are to be added
         * @param vertices the vertices to be added to the graph
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return <tt>true</tt> if graph changed as a result of the call
         *
         * @throws NullPointerException if the specified vertices contains one or more null vertices, or
         *         if the specified vertex collection is <tt>
         * null</tt>.
         *
         * @see Graph#addVertex(Object)
         */
        public static bool addAllVertices<V,E>( Graph<  V,   E> destination, ICollection<  V> vertices)
        {
            bool modified = false;

            foreach (V v in vertices)
            {
                modified |= destination.addVertex(v);
            }

            return modified;
        }

        /**
         * Returns a list of vertices that are the neighbors of a specified vertex. If the graph is a
         * multigraph vertices may appear more than once in the returned list.
         * 
         * <p>
         * The method uses {@link Graph#edgesOf(Object)} to traverse the graph.
         *
         * @param g the graph to look for neighbors in
         * @param vertex the vertex to get the neighbors of
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return a list of the vertices that are the neighbors of the specified vertex.
         */
        public static List<V> neighborListOf<V,E>(Graph<V, E> g, V vertex)
        {
            List<V> neighbors = new List<V>();

            foreach (E e in g.edgesOf(vertex))
            {
                neighbors.Add(getOppositeVertex(g, e, vertex));
            }

            return neighbors;
        }

        /**
         * Returns a list of vertices that are the direct predecessors of a specified vertex. If the
         * graph is a multigraph, vertices may appear more than once in the returned list.
         * 
         * <p>
         * The method uses {@link Graph#incomingEdgesOf(Object)} to traverse the graph.
         * 
         * @param g the graph to look for predecessors in
         * @param vertex the vertex to get the predecessors of
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return a list of the vertices that are the direct predecessors of the specified vertex.
         */
        public static List<V> predecessorListOf<V,E>(Graph<V, E> g, V vertex)
        {
            List<V> predecessors = new List<V>();
            HashSet < E > edges = g.incomingEdgesOf(vertex);

            foreach (E e in edges)
            {
                predecessors.Add(getOppositeVertex(g, e, vertex));
            }

            return predecessors;
        }

        /**
         * Returns a list of vertices that are the direct successors of a specified vertex. If the graph
         * is a multigraph vertices may appear more than once in the returned list.
         *
         * <p>
         * The method uses {@link Graph#outgoingEdgesOf(Object)} to traverse the graph.
         *
         * @param g the graph to look for successors in
         * @param vertex the vertex to get the successors of
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return a list of the vertices that are the direct successors of the specified vertex.
         */
        public static List<V> successorListOf<V,E>(Graph<V, E> g, V vertex)
        {
            List<V> successors = new List<V>();
            HashSet < E > edges = g.outgoingEdgesOf(vertex);

            foreach (E e in edges)
            {
                successors.Add(getOppositeVertex(g, e, vertex));
            }

            return successors;
        }

        /**
         * Returns an undirected view of the specified graph. If the specified graph is directed,
         * returns an undirected view of it. If the specified graph is already undirected, just returns
         * it.
         *
         * @param g the graph for which an undirected view is to be returned
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return an undirected view of the specified graph, if it is directed, or or the specified
         *         graph itself if it is already undirected.
         *
         * @throws IllegalArgumentException if the graph is neither directed nor undirected
         * @see AsUndirectedGraph
         */
        public static  Graph<V, E> undirectedGraph<V,E>(Graph<V, E> g)
        {
            if (g.getType().isDirected())
            {

                throw new NotImplementedException();
                //return new AsUndirectedGraph<>(g);
            }
            else if (g.getType().isUndirected())
            {
                return g;
            }
            else
            {
                throw new ArgumentException("graph must be either directed or undirected");
            }
        }

        /**
         * Tests whether an edge is incident to a vertex.
         *
         * @param g graph containing e and v
         * @param e edge in g
         * @param v vertex in g
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return true iff e is incident on v
         */
        public static  bool testIncidence<V,E>(Graph<V, E> g, E e, V v)
        {
            return (g.getEdgeSource(e).Equals(v)) || (g.getEdgeTarget(e).Equals(v));
        }

        /**
         * Gets the vertex opposite another vertex across an edge.
         *
         * @param g graph containing e and v
         * @param e edge in g
         * @param v vertex in g
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return vertex opposite to v across e
         */
        public static  V getOppositeVertex<V,E>(Graph<V, E> g, E e, V v)
        {
            V source = g.getEdgeSource(e);
            V target = g.getEdgeTarget(e);
            if (v.Equals(source))
            {
                return target;
            }
            else if (v.Equals(target))
            {
                return source;
            }
            else
            {
                throw new ArgumentException("no such vertex: " + v.ToString());
            }
        }

        /**
         * Removes the given vertex from the given graph. If the vertex to be removed has one or more
         * predecessors, the predecessors will be connected directly to the successors of the vertex to
         * be removed.
         *
         * @param graph graph to be mutated
         * @param vertex vertex to be removed from this graph, if present
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return true if the graph contained the specified vertex; false otherwise.
         */
        public static  bool removeVertexAndPreserveConnectivity<V,E>(Graph<V, E> graph, V vertex)
        {
            if (!graph.containsVertex(vertex))
            {
                return false;
            }

            if (vertexHasPredecessors(graph, vertex))
            {
                List<V> predecessors = Graphs.predecessorListOf(graph, vertex);
                List<V> successors = Graphs.successorListOf(graph, vertex);

                foreach (V predecessor in predecessors)
                {
                    addOutgoingEdges(graph, predecessor, successors);
                }
            }

            graph.removeVertex(vertex);
            return true;
        }

        /**
         * Filters vertices from the given graph and subsequently removes them. If the vertex to be
         * removed has one or more predecessors, the predecessors will be connected directly to the
         * successors of the vertex to be removed.
         *
         * @param graph graph to be mutated
         * @param predicate a non-interfering stateless predicate to apply to each vertex to determine
         *        if it should be removed from the graph
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return true if at least one vertex has been removed; false otherwise.
         */
        public static bool removeVerticesAndPreserveConnectivity<V,E>(Graph<V, E> graph, Predicate<V> predicate)
        {
            List<V> verticesToRemove = new List<V>();

            foreach (V node in graph.vertexSet())
            {
                if (predicate(node))
                {
                    verticesToRemove.Add(node);
                }
            }

            return removeVertexAndPreserveConnectivity(graph, verticesToRemove);
        }

        /**
         * Removes all the given vertices from the given graph. If the vertex to be removed has one or
         * more predecessors, the predecessors will be connected directly to the successors of the
         * vertex to be removed.
         *
         * @param graph to be mutated
         * @param vertices vertices to be removed from this graph, if present
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return true if at least one vertex has been removed; false otherwise.
         */
        public static  bool removeVertexAndPreserveConnectivity<V,E>(Graph<V, E> graph, ICollection<V> vertices)
        {
            bool atLeastOneVertexHasBeenRemoved = false;

            foreach (V vertex in vertices)
            {
                if (removeVertexAndPreserveConnectivity(graph, vertex))
                {
                    atLeastOneVertexHasBeenRemoved = true;
                }
            }

            return atLeastOneVertexHasBeenRemoved;
        }

        /**
         * Add edges from one source vertex to multiple target vertices. Whether duplicates are created
         * depends on the underlying {@link DirectedGraph} implementation.
         *
         * @param graph graph to be mutated
         * @param source source vertex of the new edges
         * @param targets target vertices for the new edges
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         */
        public static void addOutgoingEdges<V,E>(Graph<V, E> graph, V source, ICollection<V> targets)
        {
            if (!graph.containsVertex(source))
            {
                graph.addVertex(source);
            }
            foreach (V target in targets)
            {
                if (!graph.containsVertex(target))
                {
                    graph.addVertex(target);
                }
                graph.addEdge(source, target);
            }
        }

        /**
         * Add edges from multiple source vertices to one target vertex. Whether duplicates are created
         * depends on the underlying {@link Graph} implementation.
         *
         * @param graph graph to be mutated
         * @param target target vertex for the new edges
         * @param sources source vertices for the new edges
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         */
        public static  void addIncomingEdges<V,E>(Graph<V, E> graph, V target, ICollection<V> sources)
        {
            if (!graph.containsVertex(target))
            {
                graph.addVertex(target);
            }
            foreach (V source in sources)
            {
                if (!graph.containsVertex(source))
                {
                    graph.addVertex(source);
                }
                graph.addEdge(source, target);
            }
        }

        /**
         * Check if a vertex has any direct successors.
         *
         * @param graph the graph to look for successors
         * @param vertex the vertex to look for successors
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return true if the vertex has any successors, false otherwise
         */
        public static  bool vertexHasSuccessors<V,E>(Graph<V, E> graph, V vertex)
        {
            return graph.outgoingEdgesOf(vertex).Count != 0;
        }

        /**
         * Check if a vertex has any direct predecessors.
         *
         * @param graph the graph to look for predecessors
         * @param vertex the vertex to look for predecessors
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         *
         * @return true if the vertex has any predecessors, false otherwise
         */
        public static  bool vertexHasPredecessors<V,E>(Graph<V, E> graph, V vertex)
        {
            return graph.incomingEdgesOf(vertex).Count != 0;
        }
    }
    // End Graphs.java
}

