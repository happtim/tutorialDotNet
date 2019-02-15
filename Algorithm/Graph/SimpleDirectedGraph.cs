using System;
using System.Collections.Generic;
using System.Reflection;

using Algorithm.Builder;

namespace Algorithm.Graph
{

    /**
     * A simple directed graph. A simple directed graph is a directed graph in which neither multiple
     * edges between any two vertices nor loops are permitted.
     * 
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     *
     */
    public class SimpleDirectedGraph<V, E> : AbstractBaseGraph<V, E>
    {

        /**
         * Creates a new simple directed graph.
         *
         * @param edgeClass class on which to base factory for edges
         */
        public SimpleDirectedGraph(Type edgeClass)
            :this(new ClassBasedEdgeFactory<V,E>(edgeClass))
        {
        }

        /**
         * Creates a new simple directed graph with the specified edge factory.
         *
         * @param ef the edge factory of the new graph.
         */
        public SimpleDirectedGraph(EdgeFactory<V, E> ef)
            :this(ef, false)
        { }

        /**
         * Creates a new simple directed graph with the specified edge factory.
         *
         * @param weighted if true the graph supports edge weights
         * @param ef the edge factory of the new graph.
         */
        public SimpleDirectedGraph(EdgeFactory<V, E> ef, bool weighted)
            :base(ef, true, false, false, weighted)
        { }


        /**
         * Create a builder for this kind of graph.
         * 
         * @param edgeClass class on which to base factory for edges
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         * @return a builder for this kind of graph
         */
        public static GraphBuilder<V, E, SimpleDirectedGraph<V, E>> createBuilder( Type edgeClass)
        {
            return new GraphBuilder<V,E,SimpleDirectedGraph<V,E>>(new SimpleDirectedGraph<V,E>(edgeClass));
        }

        /**
         * Create a builder for this kind of graph.
         * 
         * @param ef the edge factory of the new graph
         * @param <V> the graph vertex type
         * @param <E> the graph edge type
         * @return a builder for this kind of graph
         */
        public static GraphBuilder<V, E,SimpleDirectedGraph<V, E>> createBuilder( EdgeFactory<V, E> ef)
        {
            return new GraphBuilder<V,E,SimpleDirectedGraph<V,E>>(new SimpleDirectedGraph<V,E>(ef));
        }


    }
    // End SimpleDirectedGraph.java
}


