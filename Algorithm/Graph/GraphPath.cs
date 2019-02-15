
using System;
using System.Collections.Generic;

namespace Algorithm.Graph
{

    /**
     * A GraphPath represents a <a href="http://mathworld.wolfram.com/Path.html"> path</a> in a
     * {@link Graph}. Unlike some definitions, the path is not required to be a
     * <a href="https://en.wikipedia.org/wiki/Simple_path">Simple Path</a>.
     *
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     *
     * @author John Sichi
     * @since Jan 1, 2008
     */
    public abstract class GraphPath<V, E>
    {
        /**
         * Returns the graph over which this path is defined. The path may also be valid with respect to
         * other graphs.
         *
         * @return the containing graph
         */
        public abstract Graph<V, E> getGraph();

        /**
         * Returns the start vertex in the path.
         *
         * @return the start vertex
         */
        public abstract V getStartVertex();

        /**
         * Returns the end vertex in the path.
         *
         * @return the end vertex
         */
        public abstract V getEndVertex();

        /**
         * Returns the edges making up the path. The first edge in this path is incident to the start
         * vertex. The last edge is incident to the end vertex. The vertices along the path can be
         * obtained by traversing from the start vertex, finding its opposite across the first edge, and
         * then doing the same successively across subsequent edges; see {@link #getVertexList()}.
         *
         * <p>
         * Whether or not the returned edge list is modifiable depends on the path implementation.
         *
         * @return list of edges traversed by the path
         */
        public virtual List<E> getEdgeList()
        {
            List<V> vertexList = this.getVertexList();
            if (vertexList.Count < 2)
                return new List<E>();

            Graph<V, E> g = this.getGraph();
            List<E> edgeList = new List<E>();
            var vertexIterator = vertexList.GetEnumerator();
            vertexIterator.MoveNext();
            V u = vertexIterator.Current;
            while (vertexIterator.MoveNext())
            {
                V v = vertexIterator.Current;
                edgeList.Add(g.getEdge(u, v));
                u = v;
            }
            return edgeList;
        }

        /**
         * Returns the path as a sequence of vertices.
         *
         * @return path, denoted by a list of vertices
         */
        public virtual List<V> getVertexList()
        {
            List<E> edgeList = this.getEdgeList();

            if (edgeList.Count == 0)
            {
                V startVertex = getStartVertex();
                if (startVertex != null && startVertex.Equals(getEndVertex()))
                {
                    return new List<V>() { startVertex };
                }
                else
                {
                    return new List<V>();
                }
            }

            Graph<V, E> g = this.getGraph();
            List<V> list = new List<V>();
            V v = this.getStartVertex();
            list.Add(v);
            foreach (E e in edgeList)
            {
                v = Graphs.getOppositeVertex(g, e, v);
                list.Add(v);
            }
            return list;
        }

        /**
         * Returns the weight assigned to the path. Typically, this will be the sum of the weights of
         * the edge list entries (as defined by the containing graph), but some path implementations may
         * use other definitions.
         *
         * @return the weight of the path
         */
        public abstract double getWeight();

        /**
         * Returns the length of the path, measured in the number of edges.
         * 
         * @return the length of the path, measured in the number of edges
         */
        int getLength()
        {
            return getEdgeList().Count;
        }

    }
    // End GraphPath.java
}

