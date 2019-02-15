using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Algorithm.Builder;

namespace Algorithm.Graph
{

    /**
     * A simple graph. A simple graph is an undirected graph for which at most one edge connects any two
     * vertices, and loops are not permitted. If you're unsure about simple graphs, see:
     * <a href="http://mathworld.wolfram.com/SimpleGraph.html">
     * http://mathworld.wolfram.com/SimpleGraph.html</a>.
     * 
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     * 
     */
    public class SimpleGraph<V, E> : AbstractBaseGraph<V, E>
{

    /**
     * Creates a new simple graph with the specified edge factory.
     *
     * @param weighted if true the graph supports edge weights
     * @param ef the edge factory of the new graph.
     */
    public SimpleGraph(EdgeFactory<V, E> ef, bool weighted)
        :base(ef, false, false, false, weighted)
    {
    }

    /**
     * Creates a new simple graph with the specified edge factory.
     *
     * @param ef the edge factory of the new graph.
     */
    public SimpleGraph(EdgeFactory<V, E> ef)
        :this(ef, false)
    {
    }

    /**
     * Creates a new simple graph.
     *
     * @param edgeClass class on which to base factory for edges
     */
    public SimpleGraph(Type edgeClass)
        :this(new ClassBasedEdgeFactory<V,E>(edgeClass))
    {
    }

    /**
     * Create a builder for this kind of graph.
     * 
     * @param edgeClass class on which to base factory for edges
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     * @return a builder for this kind of graph
     */
    public static  GraphBuilder<V, E,  SimpleGraph<V, E>> createBuilder(Type  edgeClass)
    {
        return new GraphBuilder<V,E,SimpleGraph<V,E>>(new SimpleGraph<V,E>(edgeClass));
    }

    /**
     * Create a builder for this kind of graph.
     * 
     * @param ef the edge factory of the new graph
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     * @return a builder for this kind of graph
     */
    public static GraphBuilder<V, E,SimpleGraph<V, E>> createBuilder(EdgeFactory<V, E> ef)
    {
        return new GraphBuilder<V,E,SimpleGraph<V,E>>(new SimpleGraph<V,E>(ef));
    }

}

// End SimpleGraph.java

}
