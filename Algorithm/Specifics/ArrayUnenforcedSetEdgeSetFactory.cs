using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Algorithm.Graph;
using Algorithm.Collections;

namespace Algorithm.Specifics
{

    /**
     * An edge set factory which creates {@link ArrayUnenforcedSet} of size 1, suitable for small degree
     * vertices.
     *
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     * 
     * @author Barak Naveh
     */
    public class ArrayUnenforcedSetEdgeSetFactory<V, E> : EdgeSetFactory<V, E>
{
    //private static final long serialVersionUID = 5936902837403445985L;

    /**
     * {@inheritDoc}
     */
    public HashSet<E> createEdgeSet(V vertex)
    {
        // NOTE: use size 1 to keep memory usage under control
        // for the common case of vertices with low degree
        return new HashSet<E>();
    }

}

}
