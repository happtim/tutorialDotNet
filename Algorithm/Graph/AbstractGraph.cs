using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.Graph
{
    /**
     * A skeletal implementation of the <tt>Graph</tt> interface, to minimize the effort required to
     * implement graph interfaces. This implementation is applicable to both: directed graphs and
     * undirected graphs.
     *
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     *
     * @author Barak Naveh
     * @see Graph
     */
    public abstract class AbstractGraph<V, E> : Graph<V, E>
    {

        /**
* Construct a new empty graph object.
*/
        protected AbstractGraph()
        {
        }

        /**
         * @see Graph#containsEdge(Object, Object)
         */
        public override bool containsEdge(V sourceVertex, V targetVertex)
        {
            return getEdge(sourceVertex, targetVertex) != null;
        }

        /**
         * @see Graph#removeAllEdges(Collection)
         */
        public override bool removeAllEdges(IEnumerable<E> edges)
        {
            bool modified = false;

            foreach (E e in edges)
            {
                modified |= removeEdge(e);
            }

            return modified;
        }

        /**
         * @see Graph#removeAllEdges(Object, Object)
         */
        public override HashSet<E> removeAllEdges(V sourceVertex, V targetVertex)
        {
            HashSet<E> removed = getAllEdges(sourceVertex, targetVertex);
            if (removed == null)
            {
                return null;
            }
            removeAllEdges(removed);

            return removed;
        }

        /**
         * @see Graph#removeAllVertices(Collection)
         */
        public override bool removeAllVertices(IEnumerable<V> vertices)
        {
            bool modified = false;

            foreach (V v in vertices)
            {
                modified |= removeVertex(v);
            }

            return modified;
        }

        /**
         * Returns a string of the parenthesized pair (V, E) representing this G=(V,E) graph. 'V' is the
         * string representation of the vertex set, and 'E' is the string representation of the edge
         * set.
         *
         * @return a string representation of this graph.
         */
        public override String ToString()
        {
            return toStringFromSets(vertexSet(), edgeSet(), this.getType().isDirected());
        }

        /**
         * Ensures that the specified vertex exists in this graph, or else throws exception.
         *
         * @param v vertex
         *
         * @return <code>true</code> if this assertion holds.
         *
         * @throws NullPointerException if specified vertex is <code>null</code>.
         * @throws IllegalArgumentException if specified vertex does not exist in this graph.
         */
        protected bool assertVertexExist(V v)
        {
            if (containsVertex(v))
            {
                return true;
            }
            else if (v == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                throw new ArgumentException("no such vertex in graph: " + v.ToString());
            }
        }

        /**
         * Removes all the edges in this graph that are also contained in the specified edge array.
         * After this call returns, this graph will contain no edges in common with the specified edges.
         * This method will invoke the {@link Graph#removeEdge(Object)} method.
         *
         * @param edges edges to be removed from this graph.
         *
         * @return <tt>true</tt> if this graph changed as a result of the call.
         *
         * @see Graph#removeEdge(Object)
         * @see Graph#containsEdge(Object)
         */
        protected bool removeAllEdges(E[] edges)
        {
            bool modified = false;

            foreach (E edge in edges)
            {
                modified |= removeEdge(edge);
            }

            return modified;
        }

        /**
         * Helper for subclass implementations of toString( ).
         *
         * @param vertexSet the vertex set V to be printed
         * @param edgeSet the edge set E to be printed
         * @param directed true to use parens for each edge (representing directed); false to use curly
         *        braces (representing undirected)
         *
         * @return a string representation of (V,E)
         */
        protected String toStringFromSets(IEnumerable<V> vertexSet, IEnumerable<E> edgeSet, bool directed)
        {
            List<String> renderedEdges = new List<string>();
            StringBuilder sb = new StringBuilder();
            foreach (E e in edgeSet)
            {
                if ((e.GetType() != typeof(DefaultEdge)) && (e.GetType() != typeof(DefaultWeightedEdge)))
                {
                    sb.Append(e.ToString());
                    sb.Append("=");
                }

                if (directed)
                {
                    sb.Append("(");
                }
                else
                {
                    sb.Append("{");
                }

                sb.Append(getEdgeSource(e));
                sb.Append(",");
                sb.Append(getEdgeTarget(e));

                if (directed)
                {
                    sb.Append(")");
                }
                else
                {
                    sb.Append("}");
                }

                // REVIEW jvs 29-May-2006: dump weight somewhere?
                renderedEdges.Add(sb.ToString());
                //                sb.setLegth(0);
            }

            return "(" + vertexSet + ", " + renderedEdges + ")";
        }

        /**
         * Returns a hash code value for this graph. The hash code of a graph is defined to be the sum
         * of the hash codes of vertices and edges in the graph. It is also based on graph topology and
         * edges weights.
         *
         * @return the hash code value this graph
         *
         * @see Object#hashCode()
         */
        /*
       public int hashCode()
       {
           int hash = vertexSet().hashCode();

           for (E e : edgeSet())
           {
               int part = e.hashCode();

               int source = getEdgeSource(e).hashCode();
               int target = getEdgeTarget(e).hashCode();

               // see http://en.wikipedia.org/wiki/Pairing_function (VK);
               int pairing = ((source + target) * (source + target + 1) / 2) + target;
               part = (27 * part) + pairing;

               long weight = (long)getEdgeWeight(e);
               part = (27 * part) + (int)(weight ^ (weight >>> 32));

               hash += part;
           }

           return hash;
       }
       */

        /**
         * Indicates whether some other object is "equal to" this graph. Returns <code>true</code> if
         * the given object is also a graph, the two graphs are instances of the same graph class, have
         * identical vertices and edges sets with the same weights.
         *
         * @param obj object to be compared for equality with this graph
         *
         * @return <code>true</code> if the specified object is equal to this graph
         *
         * @see Object#Equals(Object)
         */
        /*
       public bool Equals(Object obj)
       {
           if (this == obj)
           {
               return true;
           }
           if ((obj == null) )
           {
               return false;
           }

           Graph<V, E> g = TypeUtil.uncheckedCast(obj, null);

           if (!vertexSet().Equals(g.vertexSet()))
           {
               return false;
           }
           if (edgeSet().size() != g.edgeSet().size())
           {
               return false;
           }

           foreach (E e in edgeSet())
           {
               V source = getEdgeSource(e);
               V target = getEdgeTarget(e);

               if (!g.containsEdge(e))
               {
                   return false;
               }

               if (!g.getEdgeSource(e).Equals(source) || !g.getEdgeTarget(e).Equals(target))
               {
                   return false;
               }

               if (Math.Abs(getEdgeWeight(e) - g.getEdgeWeight(e)) > 10e-7)
               {
                   return false;
               }
           }

           return true;
       }
       */
    }

    // End AbstractGraph.java

}
