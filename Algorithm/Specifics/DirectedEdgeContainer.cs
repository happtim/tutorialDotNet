using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Algorithm.Graph;

namespace Algorithm.Specifics
{

    /**
     * A container for vertex edges.
     *
     * <p>
     * In this edge container we use array lists to minimize memory toll. However, for high-degree
     * vertices we replace the entire edge container with a direct access subclass (to be implemented).
     * 
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     *
     * @author Barak Naveh
     */
    public class DirectedEdgeContainer<V, E>
    {
        public HashSet<E> incoming;
        public HashSet<E> outgoing;

        private HashSet<E> unmodifiableIncoming = null;
        private HashSet<E> unmodifiableOutgoing = null;

        public DirectedEdgeContainer(EdgeSetFactory<V, E> edgeSetFactory, V vertex)
        {
            incoming = edgeSetFactory.createEdgeSet(vertex);
            outgoing = edgeSetFactory.createEdgeSet(vertex);
        }

        /**
         * A lazy build of unmodifiable incoming edge set.
         *
         * @return an unmodifiable version of the incoming edge set
         */
        public HashSet<E> getUnmodifiableIncomingEdges()
        {
            if (unmodifiableIncoming == null)
            {
                unmodifiableIncoming = new HashSet<E>(incoming);
            }

            return unmodifiableIncoming;
        }

        /**
         * A lazy build of unmodifiable outgoing edge set.
         *
         * @return an unmodifiable version of the outgoing edge set
         */
        public HashSet<E> getUnmodifiableOutgoingEdges()
        {
            if (unmodifiableOutgoing == null)
            {
                unmodifiableOutgoing = new HashSet<E>(outgoing);
            }

            return unmodifiableOutgoing;
        }

        /**
         * Add an incoming edge.
         *
         * @param e the edge to add
         */
        public void addIncomingEdge(E e)
        {
            incoming.Add(e);
        }

        /**
         * Add an outgoing edge.
         *
         * @param e the edge to add
         */
        public void addOutgoingEdge(E e)
        {
            outgoing.Add(e);
        }

        /**
         * Remove an incoming edge.
         *
         * @param e the edge to remove
         */
        public void removeIncomingEdge(E e)
        {
            incoming.Remove(e);
        }

        /**
         * Remove an outgoing edge.
         *
         * @param e the edge to remove
         */
        public void removeOutgoingEdge(E e)
        {
            outgoing.Remove(e);
        }
    }

}
