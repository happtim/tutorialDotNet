using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{

    /**
     * A base implementation for the intrusive edges specifics.
     * 
     * @author Barak Naveh
     * @author Dimitrios Michail
     *
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     * @param <IE> the intrusive edge type
     */
    public abstract class BaseIntrusiveEdgesSpecifics<V, E, IE>
        where IE : IntrusiveEdge
    {
        //private static final long serialVersionUID = -7498268216742485L;

        protected Dictionary<E, IE> edgeMap;
        protected HashSet<E> unmodifiableEdgeSet = null;

        /**
         * Constructor
         */
        public BaseIntrusiveEdgesSpecifics()
        {
            this.edgeMap = new Dictionary<E, IE>();
        }

        /**
         * Check if an edge exists
         * 
         * @param e the edge
         * @return true if the edge exists, false otherwise
         */
        public bool containsEdge(E e)
        {
            return edgeMap.ContainsKey(e);
        }

        /**
         * Get the edge set.
         * 
         * @return an unmodifiable edge set
         */
        public HashSet<E> getEdgeSet()
        {
            if (unmodifiableEdgeSet == null)
            {
                unmodifiableEdgeSet = new HashSet<E>(edgeMap.Keys);
            }
            return unmodifiableEdgeSet;
        }

        /**
         * Remove an edge.
         * 
         * @param e the edge
         */
        public void remove(E e)
        {
            edgeMap.Remove(e);
        }

        /**
         * Get the source of an edge.
         * 
         * @param e the edge
         * @return the source vertex of an edge
         */
        public V getEdgeSource(E e)
        {
            IntrusiveEdge ie = getIntrusiveEdge(e);
            if (ie == null)
            {
                throw new ArgumentException("no such edge in graph: " + e.ToString());
            }
            return (V)ie.source;
        }

        /**
         * Get the target of an edge.
         * 
         * @param e the edge
         * @return the target vertex of an edge
         */
        public V getEdgeTarget(E e)
        {
            IntrusiveEdge ie = getIntrusiveEdge(e);
            if (ie == null)
            {
                throw new ArgumentException("no such edge in graph: " + e.ToString());
            }
            return (V)ie.target;
        }

        /**
         * Get the weight of an edge.
         * 
         * @param e the edge
         * @return the weight of an edge
         */
        public virtual double getEdgeWeight(E e)
        {
            return Graph<V, E>.DEFAULT_EDGE_WEIGHT;
        }

        /**
         * Set the weight of an edge
         * 
         * @param e the edge
         * @param weight the new weight
         */
        public virtual void setEdgeWeight(E e, double weight)
        {
            throw new NotImplementedException();
        }

        /**
         * Add a new edge
         * 
         * @param e the edge
         * @param sourceVertex the source vertex of the edge
         * @param targetVertex the target vertex of the edge
         */
        public abstract void add(E e, V sourceVertex, V targetVertex);

        /**
         * Get the intrusive edge of an edge.
         * 
         * @param e the edge
         * @return the intrusive edge
         */
        protected abstract IE getIntrusiveEdge(E e);
    }

}
