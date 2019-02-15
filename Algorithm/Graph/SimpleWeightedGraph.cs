using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Algorithm.Builder;

namespace Algorithm.Graph
{

    /**
     * A simple weighted graph.
     * 
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     */
    public class SimpleWeightedGraph<V, E> : SimpleGraph<V, E>
{

    /**
     * Creates a new simple weighted graph with the specified edge factory.
     *
     * @param ef the edge factory of the new graph.
     */
    public SimpleWeightedGraph(EdgeFactory<V, E> ef)
        :base(ef, true)
    {
    }

    /**
     * Creates a new simple weighted graph.
     *
     * @param edgeClass class on which to base factory for edges
     */
    public SimpleWeightedGraph(Type edgeClass)
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
    public new static GraphBuilder<V, E, SimpleWeightedGraph<V, E>> createBuilder(Type  edgeClass)
    {
        return new GraphBuilder<V,E,SimpleWeightedGraph<V,E>>(new SimpleWeightedGraph<V,E>(edgeClass));
    }

    /**
     * Create a builder for this kind of graph.
     * 
     * @param ef the edge factory of the new graph
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     * @return a builder for this kind of graph
     */
    public new static GraphBuilder<V, E, SimpleWeightedGraph<V, E>> createBuilder( EdgeFactory<V, E> ef)
    {
        return new GraphBuilder<V,E,SimpleWeightedGraph<V,E>>(new SimpleWeightedGraph<V,E>(ef));
    }

}

// End SimpleWeightedGraph.java

}
