using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
    /**
     * A default implementation for edges in a {@link Graph}.
     *
     * @author Barak Naveh
     * @since Jul 14, 2003
     */
    public class DefaultEdge : IntrusiveEdge
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

    public override 
        String ToString()
    {
        return "(" + source + " : " + target + ")";
    }
}

// End DefaultEdge.java

}
