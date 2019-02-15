using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    /**
     * A weighted variant of the intrusive edges specifics.
     * 
     * <p>
     * The implementation optimizes the use of {@link DefaultWeightedEdge} and subclasses. For other
     * custom user edge types, a map is used to store vertex source, target and weight.
     * 
     * @author Barak Naveh
     * @author Dimitrios Michail
     *
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     */
    public class WeightedIntrusiveEdgesSpecifics<V, E> :
        BaseIntrusiveEdgesSpecifics<V, E, IntrusiveWeightedEdge>
        , IntrusiveEdgesSpecifics<V, E>
    {
        //private static final long serialVersionUID = 5327226615635500554L;

        /**
         * Constructor
         */
        public WeightedIntrusiveEdgesSpecifics()
                : base()
        {
        }

        public override void add(E e, V sourceVertex, V targetVertex)
        {
            IntrusiveWeightedEdge intrusiveEdge;
            if (e is IntrusiveWeightedEdge)
            {
                intrusiveEdge = e as IntrusiveWeightedEdge;
            }
            else
            {
                intrusiveEdge = new IntrusiveWeightedEdge();
            }
            intrusiveEdge.source = sourceVertex;
            intrusiveEdge.target = targetVertex;
            edgeMap[e] = intrusiveEdge;
        }

        public override double getEdgeWeight(E e)
        {
            IntrusiveWeightedEdge ie = getIntrusiveEdge(e);
            if (ie == null)
            {
                throw new ArgumentException("no such edge in graph: " + e.ToString());
            }
            return ie.weight;
        }

        public override void setEdgeWeight(E e, double weight)
        {
            IntrusiveWeightedEdge ie = getIntrusiveEdge(e);
            if (ie == null)
            {
                throw new ArgumentException("no such edge in graph: " + e.ToString());
            }
            ie.weight = weight;
        }

        protected override IntrusiveWeightedEdge getIntrusiveEdge(E e)
        {
            if (e is IntrusiveWeightedEdge)
            {
                return e as IntrusiveWeightedEdge;
            }
            return edgeMap[e];
        }
    }

}
