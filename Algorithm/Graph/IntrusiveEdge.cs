using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{

    /**
     * IntrusiveEdge encapsulates the internals for the default edge implementation. It is not intended
     * to be referenced directly (which is why it's not public); use DefaultEdge for that.
     *
     * @author John V. Sichi
     */
    public class IntrusiveEdge 
{
    //private static final long serialVersionUID = 3258408452177932855L;

    public object source;

    public object target;

    /**
     * @see Object#clone()
     */
     /*
    public Object clone()
    {
        try
        {
            return super.clone();
        }
        catch (CloneNotSupportedException e)
        {
            // shouldn't happen as we are Cloneable
            throw new InternalError();
        }
    }
    */
}

// End IntrusiveEdge.java

}
