using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{

    /**
     * A default implementation for edges in a weighted graph. All access to the weight of an edge must
     * go through the graph interface, which is why this class doesn't expose any public methods.
     *
     * @author John V. Sichi
     */
    public class DefaultWeightedEdge : IntrusiveWeightedEdge
    {

    /**
     * Retrieves the source of this edge. This is protected, for use by subclasses only (e.g. for
     * implementing toString).
     *
     * @return source of this edge
     */
    protected Object getSource()
    {
        return source;
    }

    /**
     * Retrieves the target of this edge. This is protected, for use by subclasses only (e.g. for
     * implementing toString).
     *
     * @return target of this edge
     */
    protected Object getTarget()
    {
        return target;
    }

    /**
     * Retrieves the weight of this edge. This is protected, for use by subclasses only (e.g. for
     * implementing toString).
     *
     * @return weight of this edge
     */
    protected double getWeight()
    {
        return weight;
    }

    public override String ToString()
    {
        return "(" + source + " : " + target + ")";
    }

}

// End DefaultWeightedEdge.java

}
