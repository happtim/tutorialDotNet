using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{

    /**
     * An interface for the set of intrusive edges of a graph.
     * 
     * <p>
     * Since the library supports edges which can be any user defined object, we need to provide
     * explicit support for storing vertex source, target and weight.
     *
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     *
     * @author Dimitrios Michail
     */
    public interface IntrusiveEdgesSpecifics<V, E>
    {
        /**
         * Get the source vertex of an edge.
         * 
         * @param e the edge
         * @return the source vertex
         */
        V getEdgeSource(E e);

        /**
         * Get the target vertex of an edge.
         * 
         * @param e the edge
         * @return the target vertex
         */
        V getEdgeTarget(E e);

        /**
         * Add a new edge.
         * 
         * @param e the edge to add
         */
        void add(E e, V sourceVertex, V targetVertex);

        /**
         * Check if an edge exists
         * 
         * @param e the input edge
         * @return true if an edge exists, false otherwise
         */
        bool containsEdge(E e);

        /**
         * Get the edge set
         * 
         * @return the edge set
         */
        HashSet<E> getEdgeSet();

        /**
         * Remove an edge.
         * 
         * @param e the edge to remove.
         */
        void remove(E e);

        /**
         * Get the weight of an edge.
         * 
         * @param e the edge
         * @return the edge weight
         */
        double getEdgeWeight(E e);

        /**
         * Set the edge weight
         * 
         * @param e the edge
         * @param weight the new weight
         */
        void setEdgeWeight(E e, double weight);
    }

}
