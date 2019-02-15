using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Algorithm.Graph
{

    /**
     * An {@link EdgeFactory} for producing edges by using a class as a factory.
     *
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     *
     * @author Barak Naveh
     * @since Jul 14, 2003
     */
    public class ClassBasedEdgeFactory<V, E> : EdgeFactory<V, E>
    {

        private Type edgeClass;

        /**
         * Create a new class based edge factory.
         * 
         * @param edgeClass the edge class
         */
        public ClassBasedEdgeFactory(Type edgeClass)
        {
            this.edgeClass = edgeClass;
        }

        /**
         * @see EdgeFactory#createEdge(Object, Object)
         */
        public E createEdge(V source, V target)
        {
            try
            {
                return (E)edgeClass.Assembly.CreateInstance(edgeClass.FullName);
            }
            catch (Exception ex)
            {
                throw new Exception("Edge factory failed", ex);
            }
        }
    }

    // End ClassBasedEdgeFactory.java

}
