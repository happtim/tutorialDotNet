using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

using Algorithm.Graph;

namespace Algorithm.ShortestPath
{

    /**
     * A walk in a graph is an alternating sequence of vertices and edges, starting and ending at a
     * vertex, in which each edge is adjacent in the sequence to its two endpoints. More precisely, a
     * walk is a connected sequence of vertices and edges in a graph
     * {@code v0, e0, v1, e1, v2,....vk-1, ek-1, vk}, such that for {@code 1<=i<=k<}, the edge
     * {@code e_i} has endpoints {@code v_(i-1)} and {@code v_i}. The class makes no assumptions with
     * respect to the shape of the walk: edges may be repeated, and the start and end point of the walk
     * may be different.
     *
     * <p>
     * See <a href="http://mathworld.wolfram.com/Walk.html">http://mathworld.wolfram.com/Walk.html</a>
     * GraphWalk is the default implementation of {@link GraphPath}.
     *
     * <p>
     * Two special cases exist:
     * <ol>
     * <li>A singleton GraphWalk has an empty edge list (the length of the path Equals 0), the vertex
     * list contains a single vertex v, and the start and end vertex equal v.</li>
     * <li>An empty Graphwalk has empty edge and vertex lists, and the start and end vertex are both
     * null.</li>
     * </ol>
     *
     * <p>
     * This class is implemented as a light-weight data structure; this class does not verify whether
     * the sequence of edges or the sequence of vertices provided during construction forms an actual
     * walk. It is the responsibility of the invoking class to provide correct input data.
     *
     *
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     *
     * @author Joris Kinable
     * 
     */
    public class GraphWalk<V, E> : GraphPath<V, E> , IEquatable< GraphWalk<V,E> >
    {
        protected Graph<V, E> graph;

        protected List<V> vertexList;
        protected List<E> edgeList;

        protected V startVertex;

        protected V endVertex;

        protected double weight;

        /**
         * Creates a walk defined by a sequence of edges. A walk defined by its edges can be specified
         * for non-simple graphs. Edge repetition is permitted, the start and end point points (v0 and
         * vk) can be different.
         *
         * @param graph the graph
         * @param startVertex the starting vertex
         * @param endVertex the last vertex of the path
         * @param edgeList the list of edges of the path
         * @param weight the total weight of the path
         */
        public GraphWalk(Graph<V, E> graph, V startVertex, V endVertex, List<E> edgeList, double weight)
            :this(graph, startVertex, endVertex, null, edgeList, weight)
        { }

        /**
         * Creates a walk defined by a sequence of vertices. Note that the input graph must be simple,
         * otherwise the vertex sequence does not necessarily define a unique path. Furthermore, all
         * vertices must be pairwise adjacent.
         * 
         * @param graph the graph
         * @param vertexList the list of vertices of the path
         * @param weight the total weight of the path
         */
        public GraphWalk(Graph<V, E> graph, List<V> vertexList, double weight)
            :this(
                graph, (vertexList.Count == 0 ? default(V) : vertexList[0]),
                (vertexList.Count == 0 ? default(V): vertexList[vertexList.Count - 1]), vertexList, null,
                weight)
        {
        }

        /**
         * Creates a walk defined by both a sequence of edges and a sequence of vertices. Note that both
         * the sequence of edges and the sequence of vertices must describe the same path! This is not
         * verified during the construction of the walk. This constructor makes it possible to store
         * both a vertex and an edge view of the same walk, thereby saving computational overhead when
         * switching from one to the other.
         *
         * @param graph the graph
         * @param startVertex the starting vertex
         * @param endVertex the last vertex of the path
         * @param vertexList the list of vertices of the path
         * @param edgeList the list of edges of the path
         * @param weight the total weight of the path
         */
        public GraphWalk(
            Graph<V, E> graph, V startVertex, V endVertex, List<V> vertexList, List<E> edgeList,
            double weight)
        {
            // Some necessary but not sufficient conditions for valid paths
            if (vertexList == null && edgeList == null)
                throw new ArgumentNullException("Vertex list and edge list cannot both be null!");
            if (startVertex != null && vertexList != null && edgeList != null
                && edgeList.Count + 1 != vertexList.Count)
                throw new ArgumentException(
                    "VertexList and edgeList do not correspond to the same path (cardinality of vertexList +1 must equal the cardinality of the edgeList)");
            if (startVertex == null ^ endVertex == null)
                throw new ArgumentException(
                    "Either the start and end vertices must both be null, or they must both be not null (one of them is null)");

            Contract.Requires(graph != null);
            this.graph = graph;
            this.startVertex = startVertex;
            this.endVertex = endVertex;
            this.vertexList = vertexList;
            this.edgeList = edgeList;
            this.weight = weight;
        }

        public override Graph<V, E> getGraph()
        {
            return graph;
        }

        public override V getStartVertex()
        {
            return startVertex;
        }

        public override V getEndVertex()
        {
            return endVertex;
        }

        public override List<E> getEdgeList()
        {
            return (edgeList != null ? edgeList : base.getEdgeList());
        }

        public override List<V> getVertexList()
        {
            return (vertexList != null ? vertexList : base.getVertexList());
        }

        public override double getWeight()
        {
            return weight;
        }

        /**
         * Updates the weight of this walk
         * 
         * @param weight weight of the walk
         */
        public void setWeight(double weight)
        {
            this.weight = weight;
        }

        public int getLength()
        {
            if (edgeList != null)
                return edgeList.Count ;
            else if (vertexList != null && vertexList.Count > 0 )
                return vertexList.Count - 1;
            else
                return 0;
        }

        public override String ToString()
        {
            if (vertexList != null)
                return vertexList.ToString();
            else
                return edgeList.ToString();
        }

        public bool Equals(GraphWalk<V, E> o)
        {
            if (o == null || !(o is GraphWalk<V,E>))
                return false;
            else if (this == o)
                return true;
            GraphWalk<V, E> other = (GraphWalk<V, E>)o;
            if (this.isEmpty() && other.isEmpty())
                return true;
            if (!this.startVertex.Equals(other.getStartVertex())
                || !this.endVertex.Equals(other.getEndVertex()))
                return false;
            // If this path is expressed as a vertex list, we may get away by comparing the other path's
            // vertex list
            // This only works if its vertexList identifies a unique path in the graph
            if (this.edgeList == null && !other.getGraph().getType().isAllowingMultipleEdges())
                return this.vertexList.Equals(other.getVertexList());
            else // Unlucky, we need to compare the edge lists,
                return this.getEdgeList().Equals(other.getEdgeList());
        }

        /*
        public override int hashCode()
        {
            int hashCode = 1;
            if (isEmpty())
                return hashCode;

            hashCode = 31 * hashCode + startVertex.hashCode();
            hashCode = 31 * hashCode + endVertex.hashCode();

            if (edgeList != null)
                return 31 * hashCode + edgeList.hashCode();
            else
                return 31 * hashCode + vertexList.hashCode();
        }
        */

        /**
         * Reverses the direction of the walk. In case of directed/mixed graphs, the arc directions will
         * be reversed. An exception is thrown if reversing an arc (u,v) is impossible because arc (v,u)
         * is not present in the graph. The weight of the resulting walk Equals the sum of edge weights
         * in the walk.
         * 
         * @throws InvalidGraphWalkException if the path is invalid
         * @return a reversed GraphWalk
         */
        public GraphWalk<V, E> reverse()
        {
            return this.reverse(null);
        }

        /**
         * Reverses the direction of the walk. In case of directed/mixed graphs, the arc directions will
         * be reversed. An exception is thrown if reversing an arc (u,v) is impossible because arc (v,u)
         * is not present in the graph.
         * 
         * @param walkWeightCalculator Function used to calculate the weight of the reversed GraphWalk
         * @throws InvalidGraphWalkException if the path is invalid
         * @return a reversed GraphWalk
         */
        public GraphWalk<V, E> reverse(Func<GraphWalk<V, E>, Double> walkWeightCalculator)
        {
            List<V> revVertexList = null;
            List<E> revEdgeList = null;
            double revWeight = 0;

            if (vertexList != null)
            {
                revVertexList = new List<V>(this.vertexList);
                revVertexList.Reverse();
                if (graph.getType().isUndirected())
                    revWeight = this.weight;

                // Check validity of the path. If the path is invalid, then calculating its weight may
                // result in an undefined exception.
                // If an edgeList is provided, then this check can be postponed to the construction of
                // the reversed edge list
                if (!graph.getType().isUndirected() && edgeList == null)
                {
                    for (int i = 0; i < revVertexList.Count - 1; i++)
                    {
                        V u = revVertexList[i];
                        V v = revVertexList[i + 1];
                        E edge = graph.getEdge(u, v);
                        if (edge == null)
                            throw new ArgumentException(
                                "this walk cannot be reversed. The graph does not contain a reverse arc for arc "
                                    + graph.getEdge(v, u));
                        else
                            revWeight += graph.getEdgeWeight(edge);
                    }
                }
            }

            if (edgeList != null)
            {
                revEdgeList = new List<E>(this.edgeList.Count);

                if (graph.getType().isUndirected())
                {
                    revEdgeList.AddRange(this.edgeList);
                    revEdgeList.Reverse();
                    revWeight = this.weight;
                }
                else
                {
                    var listIterator = edgeList.GetEnumerator();
                    while (listIterator.MoveNext())
                    {
                        E e = listIterator.Current;
                        V u = graph.getEdgeSource(e);
                        V v = graph.getEdgeTarget(e);
                        E revEdge = graph.getEdge(v, u);
                        if (revEdge == null)
                            throw new ArgumentException(
                                "this walk cannot be reversed. The graph does not contain a reverse arc for arc "
                                    + e);
                        revEdgeList.Add(revEdge);
                        revWeight += graph.getEdgeWeight(revEdge);
                    }
                }
            }
            // Update weight of reversed walk
            GraphWalk<V, E> gw = new GraphWalk<V,E>(
                this.graph, this.endVertex, this.startVertex, revVertexList, revEdgeList, 0);
            if (walkWeightCalculator == null)
                gw.weight = revWeight;
            else
                gw.weight = walkWeightCalculator(gw);
            return gw;
        }

        /**
         * Concatenates the specified GraphWalk to the end of this GraphWalk. This action can only be
         * performed if the end vertex of this GraphWalk is the same as the start vertex of the
         * extending GraphWalk
         * 
         * @param extension GraphPath used for the concatenation.
         * @param walkWeightCalculator Function used to calculate the weight of the GraphWalk obtained
         *        after the concatenation.
         * @return a GraphWalk that represents the concatenation of this object's walk followed by the
         *         walk specified in the extension argument.
         */
        public GraphWalk<V, E> concat(
            GraphWalk<V, E> extension, Func<GraphWalk<V, E>, Double> walkWeightCalculator)
        {
            if (this.isEmpty())
                throw new ArgumentException("An empty path cannot be extended");
            if (!this.endVertex.Equals(extension.getStartVertex()))
                throw new ArgumentException(
                    "This path can only be extended by another path if the end vertex of the orginal path and the start vertex of the extension are equal.");

            List<V> concatVertexList = null;
            List<E> concatEdgeList = null;

            if (vertexList != null)
            {
                concatVertexList = new List<V>(this.vertexList);
                List<V> vertexListExtension = extension.getVertexList();
                concatVertexList.AddRange(vertexListExtension.Skip(1));
            }

            if (edgeList != null)
            {
                concatEdgeList = new List<E>(this.edgeList);
                concatEdgeList.AddRange(extension.getEdgeList());
            }

            GraphWalk<V, E> gw = new GraphWalk<V,E>(
                this.graph, startVertex, extension.getEndVertex(), concatVertexList, concatEdgeList, 0);
            gw.setWeight(walkWeightCalculator(gw));
            return gw;
        }

        /**
         * Returns true if the path is an empty path, that is, a path with startVertex=endVertex=null
         * and with an empty vertex and edge list.
         * 
         * @return Returns true if the path is an empty path.
         */
        public bool isEmpty()
        {
            return startVertex == null;
        }

        /**
         * Convenience method which verifies whether the given path is feasible wrt the input graph and
         * forms an actual path.
         * 
         * @throws InvalidGraphWalkException if the path is invalid
         */
        public void verify()
        {

            if (isEmpty()) // Empty path
                return;

            if (vertexList != null && vertexList.Count > 0 )
            {
                if (!startVertex.Equals(vertexList[0]))
                    throw new ArgumentException( "The start vertex must be the first vertex in the vertex list");
                if (!endVertex.Equals(vertexList[vertexList.Count - 1]))
                    throw new ArgumentException( "The end vertex must be the last vertex in the vertex list");
                // All vertices and edges in the path must be contained in the graph
                if (!graph.vertexSet().IsSupersetOf(vertexList))
                    throw new ArgumentException( "Not all vertices in the path are contained in the graph");

                if (edgeList == null)
                {
                    // Verify sequence
                    var it = vertexList.GetEnumerator();
                    it.MoveNext();
                    V u = it.Current;
                    while (it.MoveNext())
                    {
                        V v = it.Current;
                        if (graph.getEdge(u, v) == null)
                            throw new ArgumentException( "The vertexList does not constitute to a feasible path. Edge (" + u + "," + v + " does not exist in the graph.");
                        u = v;
                    }
                }
            }

            if (edgeList != null && edgeList .Count > 0)
            {
                if (!Graphs.testIncidence(graph, edgeList[0], startVertex))
                    throw new ArgumentException( "The first edge in the edge list must leave the start vertex");
                if (!graph.edgeSet().IsSupersetOf(edgeList))
                    throw new ArgumentException( "Not all edges in the path are contained in the graph");

                if (vertexList == null)
                {
                    V u = startVertex;
                    foreach (E edge in edgeList)
                    {
                        if (!Graphs.testIncidence(graph, edge, u))
                            throw new ArgumentException( "The edgeList does not constitute to a feasible path. Conflicting edge: " + edge);
                        u = Graphs.getOppositeVertex(graph, edge, u);
                    }
                    if (!u.Equals(endVertex))
                        throw new ArgumentException(
                            "The path defined by the edgeList does not end in the endVertex.");
                }
            }

            if (vertexList != null && edgeList != null)
            {
                // Verify that the path is an actual path in the graph
                if (edgeList.Count + 1 != vertexList.Count )
                    throw new ArgumentException(
                        "VertexList and edgeList do not correspond to the same path (cardinality of vertexList +1 must equal the cardinality of the edgeList)");

                for (int i = 0; i < vertexList.Count - 1; i++)
                {
                    V u = vertexList[i];
                    V v = vertexList[i + 1];
                    E edge = getEdgeList()[i];

                    if (graph.getType().isDirected())
                    { // Directed graph
                        if (!graph.getEdgeSource(edge).Equals(u)
                            || !graph.getEdgeTarget(edge).Equals(v))
                            throw new ArgumentException( "VertexList and edgeList do not form a feasible path");
                    }
                    else
                    { // Undirected or mixed
                        if (!Graphs.testIncidence(graph, edge, u)
                            || !Graphs.getOppositeVertex(graph, edge, u).Equals(v))
                            throw new ArgumentException(
                                "VertexList and edgeList do not form a feasible path");
                    }
                }
            }
        }

        /**
         * Convenience method which creates an empty walk.
         * 
         * @param graph input graph
         * @param <V> vertex type
         * @param <E> edge type
         * @return an empty walk
         */
        public static GraphWalk<V, E> emptyWalk(Graph<V, E> graph)
        {
            return new GraphWalk<V,E>(
                graph, default(V), default(V), new List<V>(),new List<E>() , 0.0);
        }

        /**
         * Convenience method which creates a walk consisting of a single vertex with weight 0.0.
         * 
         * @param graph input graph
         * @param v single vertex
         * @param <V> vertex type
         * @param <E> edge type
         * @return an empty walk
         */
        public static  GraphWalk<V, E> singletonWalk(Graph<V, E> graph, V v)
        {
            return singletonWalk(graph, v, 0d);
        }

        /**
         * Convenience method which creates a walk consisting of a single vertex.
         * 
         * @param graph input graph
         * @param v single vertex
         * @param weight weight of the path
         * @param <V> vertex type
         * @param <E> edge type
         * @return an empty walk
         */
        public static GraphWalk<V, E> singletonWalk(Graph<V, E> graph, V v, double weight)
        {
            return new GraphWalk<V,E>(
                graph, v, v, new List<V>(){v}, new List<E>(), weight);
        }

       
    }

    /**
     * Exception thrown in the event that the path is invalid.
     */
    class InvalidGraphWalkException : Exception
    {
        public InvalidGraphWalkException(String message)
            :base(message)
        {
        }

    }
    // End GraphPathImpl.java
}

