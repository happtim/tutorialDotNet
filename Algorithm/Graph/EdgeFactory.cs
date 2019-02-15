
namespace Algorithm.Graph
{

    /**
     * An edge factory used by graphs for creating new edges.
     *
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     *
     * @author Barak Naveh
     * @since Jul 14, 2003
     */
    public interface EdgeFactory<V, E>
    {
        /**
         * Creates a new edge whose endpoints are the specified source and target vertices.
         *
         * @param sourceVertex the source vertex.
         * @param targetVertex the target vertex.
         *
         * @return a new edge whose endpoints are the specified source and target vertices.
         */
        E createEdge(V sourceVertex, V targetVertex);
    }
    // End EdgeFactory.java
}

