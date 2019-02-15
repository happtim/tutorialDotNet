
namespace Algorithm.Graph
{

    /**
     * A graph type.
     * 
     * <p>
     * The graph type describes various properties of a graph such as whether it is directed/undirected
     * or mixed, whether it contain self-loops (edges with the same source and target vertices), whether
     * it contain parallel-edges (multiple edges with the same source and target) and whether it is
     * weighted or not.
     * 
     * @author Dimitrios Michail
     */
    public interface GraphType
    {
        /**
         * Returns true if all edges of the graph are directed, false otherwise.
         * 
         * @return true if all edges of the graph are directed, false otherwise
         */
        bool isDirected();

        /**
         * Returns true if all edges of the graph are undirected, false otherwise.
         * 
         * @return true if all edges of the graph are undirected, false otherwise
         */
        bool isUndirected();

        /**
         * Returns true if the graph contain both directed and undirected edges, false otherwise.
         * 
         * @return true if the graph contain both directed and undirected edges, false otherwise
         */
        bool isMixed();

        /**
         * Returns <code>true</code> if and only if multiple edges are allowed in this graph. The
         * meaning of multiple edges is that there can be many edges going from vertex v1 to vertex v2.
         *
         * @return <code>true</code> if and only if multiple edges are allowed.
         */
        bool isAllowingMultipleEdges();

        /**
         * Returns <code>true</code> if and only if self-loops are allowed in this graph. A self loop is
         * an edge that its source and target vertices are the same.
         *
         * @return <code>true</code> if and only if graph self-loops are allowed.
         */
        bool isAllowingSelfLoops();

        /**
         * Returns <code>true</code> if and only if cycles are allowed in this graph.
         *
         * @return <code>true</code> if and only if graph cycles are allowed.
         */
        bool isAllowingCycles();

        /**
         * Returns <code>true</code> if and only if the graph supports edge weights.
         *
         * @return <code>true</code> if the graph supports edge weights, <code>false</code> otherwise.
         */
        bool isWeighted();

        /**
         * Returns <code>true</code> if the graph is simple, <code>false</code> otherwise.
         * 
         * @return <code>true</code> if the graph is simple, <code>false</code> otherwise
         */
        bool isSimple();

        /**
         * Returns <code>true</code> if the graph is a pseudograph, <code>false</code> otherwise.
         * 
         * @return <code>true</code> if the graph is a pseudograph, <code>false</code> otherwise
         */
        bool isPseudograph();

        /**
         * Returns <code>true</code> if the graph is a multigraph, <code>false</code> otherwise.
         * 
         * @return <code>true</code> if the graph is a multigraph, <code>false</code> otherwise
         */
        bool isMultigraph();

        /**
         * Returns <code>true</code> if the graph is modifiable, <code>false</code> otherwise.
         * 
         * @return <code>true</code> if the graph is modifiable, <code>false</code> otherwise
         */
        bool isModifiable();

        /**
         * Create a directed variant of the current graph type.
         * 
         * @return a directed variant of the current graph type
         */
        GraphType asDirected();

        /**
         * Create an undirected variant of the current graph type.
         * 
         * @return an undirected variant of the current graph type
         */
        GraphType asUndirected();

        /**
         * Create a mixed variant of the current graph type.
         * 
         * @return a mixed variant of the current graph type
         */
        GraphType asMixed();

        /**
         * Create an unweighted variant of the current graph type.
         * 
         * @return an unweighted variant of the current graph type
         */
        GraphType asUnweighted();

        /**
         * Create a weighted variant of the current graph type.
         * 
         * @return a weighted variant of the current graph type
         */
        GraphType asWeighted();

        /**
         * Create a modifiable variant of the current graph type.
         * 
         * @return a modifiable variant of the current graph type
         */
        GraphType asModifiable();

        /**
         * Create an unmodifiable variant of the current graph type.
         * 
         * @return a unmodifiable variant of the current graph type
         */
        GraphType asUnmodifiable();
    }
}

