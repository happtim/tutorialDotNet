using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Algorithm.Builder;

namespace Algorithm.Graph
{


    /**
     * A simple directed weighted graph. A simple directed weighted graph is a simple directed graph for
     * which edges are assigned weights.
     * 
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     */
    public class SimpleDirectedWeightedGraph<V, E> : SimpleDirectedGraph<V, E>
{

    /**
     * Creates a new simple directed weighted graph with the specified edge factory.
     *
     * @param ef the edge factory of the new graph.
     */
    public SimpleDirectedWeightedGraph(EdgeFactory<V, E> ef)
        :base(ef, true)
    {
    }

    /**
     * Creates a new simple directed weighted graph.
     *
     * @param edgeClass class on which to base factory for edges
     */
    public SimpleDirectedWeightedGraph(Type edgeClass)
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
    public new static  GraphBuilder<V, E,  SimpleDirectedWeightedGraph<V, E>> createBuilder(Type  edgeClass)
    {
        return new GraphBuilder<V,E, SimpleDirectedWeightedGraph<V,E>>(new SimpleDirectedWeightedGraph<V,E>(edgeClass));
    }

    /**
     * Create a builder for this kind of graph.
     * 
     * @param ef the edge factory of the new graph
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     * @return a builder for this kind of graph
     */
    public new static  GraphBuilder<V, E, SimpleDirectedWeightedGraph<V, E>> createBuilder( EdgeFactory<V, E> ef)
    {
        return new GraphBuilder<V,E, SimpleDirectedWeightedGraph<V,E>>(new SimpleDirectedWeightedGraph<V,E>(ef));
    }

}

// End SimpleDirectedWeightedGraph.java
 


}
