using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{

    /**
     * Default implementation of the graph type.
     * 
     * <p>
     * The graph type describes various properties of a graph such as whether it is directed, undirected
     * or mixed, whether it contain self-loops (edges with the same source and target vertices), whether
     * it contain parallel-edges (multiple edges with the same source and target) and whether it is
     * weighted or not.
     * 
     * @author Dimitrios Michail
     */
    public class DefaultGraphType : GraphType 
{
    //private static final long serialVersionUID = 4291049312119347474L;

    private  bool directed;
    private  bool undirected;
    private  bool selfLoops;
    private  bool multipleEdges;
    private  bool weighted;
    private  bool allowsCycles;
    private  bool modifiable;

    private DefaultGraphType(
        bool directed, bool undirected, bool selfLoops, bool multipleEdges,
        bool weighted, bool allowsCycles, bool modifiable)
    {
        this.directed = directed;
        this.undirected = undirected;
        this.selfLoops = selfLoops;
        this.multipleEdges = multipleEdges;
        this.weighted = weighted;
        this.allowsCycles = allowsCycles;
        this.modifiable = modifiable;
    }

    public bool isDirected()
    {
        return directed && !undirected;
    }

    public bool isUndirected()
    {
        return undirected && !directed;
    }

    public bool isMixed()
    {
        return undirected && directed;
    }

    public bool isAllowingMultipleEdges()
    {
        return multipleEdges;
    }

    public bool isAllowingSelfLoops()
    {
        return selfLoops;
    }

    public bool isWeighted()
    {
        return weighted;
    }

    public bool isAllowingCycles()
    {
        return allowsCycles;
    }

    public bool isModifiable()
    {
        return modifiable;
    }

    public bool isSimple()
    {
        return !isAllowingMultipleEdges() && !isAllowingSelfLoops();
    }

    public bool isPseudograph()
    {
        return isAllowingMultipleEdges() && isAllowingSelfLoops();
    }

    public bool isMultigraph()
    {
        return isAllowingMultipleEdges() && !isAllowingSelfLoops();
    }

    public GraphType asDirected()
    {
        return new Builder(this).Directed().build();
    }

    public GraphType asUndirected()
    {
        return new Builder(this).Undirected().build();
    }

    public GraphType asMixed()
    {
        return new Builder(this).Mixed().build();
    }

    public GraphType asUnweighted()
    {
        return new Builder(this).Weighted(false).build();
    }

    public GraphType asWeighted()
    {
        return new Builder(this).Weighted(true).build();
    }

    public GraphType asModifiable()
    {
        return new Builder(this).Modifiable(true).build();
    }

    public GraphType asUnmodifiable()
    {
        return new Builder(this).Modifiable(false).build();
    }

    /**
     * A simple graph type. An undirected graph for which at most one edge connects any two
     * vertices, and self-loops are not permitted.
     * 
     * @return a simple graph type
     */
    public static DefaultGraphType simple()
    {
        return new Builder()
            .Undirected().AllowSelfLoops(false).AllowMultipleEdges(false).Weighted(false).build();
    }

    /**
     * A multigraph type. A non-simple undirected graph in which no self-loops are permitted, but
     * multiple edges between any two vertices are.
     * 
     * @return a multigraph type
     */
    public static DefaultGraphType multigraph()
    {
        return new Builder()
            .Undirected().AllowSelfLoops(false).AllowMultipleEdges(true).Weighted(false).build();
    }

    /**
     * A pseudograph type. A non-simple undirected graph in which both graph self-loops and multiple
     * edges are permitted.
     * 
     * @return a pseudograph type
     */
    public static DefaultGraphType pseudograph()
    {
        return new Builder()
            .Undirected().AllowSelfLoops(true).AllowMultipleEdges(true).Weighted(false).build();
    }

    /**
     * A directed simple graph type. An undirected graph for which at most one edge connects any two
     * vertices, and self-loops are not permitted.
     * 
     * @return a directed simple graph type
     */
    public static DefaultGraphType directedSimple()
    {
        return new Builder()
            .Directed().AllowSelfLoops(false).AllowMultipleEdges(false).Weighted(false).build();
    }

    /**
     * A directed multigraph type. A non-simple undirected graph in which no self-loops are
     * permitted, but multiple edges between any two vertices are.
     * 
     * @return a directed multigraph type
     */
    public static DefaultGraphType directedMultigraph()
    {
        return new Builder()
            .Directed().AllowSelfLoops(false).AllowMultipleEdges(true).Weighted(false).build();
    }

    /**
     * A directed pseudograph type. A non-simple undirected graph in which both graph self-loops and
     * multiple edges are permitted.
     * 
     * @return a directed pseudograph type
     */
    public static DefaultGraphType directedPseudograph()
    {
        return new Builder()
            .Directed().AllowSelfLoops(true).AllowMultipleEdges(true).Weighted(false).build();
    }

    /**
     * A mixed graph type. A graph having a set of undirected and a set of directed edges, which may
     * contain self-loops and multiple edges are permitted.
     * 
     * @return a mixed graph type
     */
    public static DefaultGraphType mixed()
    {
        return new Builder()
            .Mixed().AllowSelfLoops(true).AllowMultipleEdges(true).Weighted(false).build();
    }

    /**
     * A directed acyclic graph.
     * 
     * @return a directed acyclic graph type
     */
    public static DefaultGraphType dag()
    {
        return  new Builder()
            .Directed().AllowSelfLoops(false).AllowMultipleEdges(true).AllowCycles(false)
            .Weighted(false).build();
    }

    /**
     * A builder for {@link DefaultGraphType}.
     * 
     * @author Dimitrios Michail
     */
    public class Builder
    {
        private bool directed;
        private bool undirected;
        private bool allowSelfLoops;
        private bool allowMultipleEdges;
        private bool weighted;
        private bool allowCycles;
        private bool modifiable;

        /**
         * Construct a new Builder.
         */
        public Builder()
        {
            directed = false;
            undirected = true;
            allowSelfLoops = true;
            allowMultipleEdges = true;
            weighted = false;
            allowCycles = true;
            modifiable = true;
        }

        /**
         * Construct a new Builder.
         * 
         * @param type the type to base the builder
         */
        public  Builder(GraphType type)
        {
            directed = type.isDirected() || type.isMixed();
            undirected = type.isUndirected() || type.isMixed();
            allowSelfLoops = type.isAllowingSelfLoops();
            allowMultipleEdges = type.isAllowingMultipleEdges();
            weighted = type.isWeighted();
            allowCycles = type.isAllowingCycles();
            modifiable = type.isModifiable();
        }

        /**
         * Set the type as directed.
         * 
         * @return the builder
         */
        public Builder Directed()
        {
            directed = true;
            undirected = false;
                return this;
        }

        /**
         * Set the type as undirected.
         * 
         * @return the builder
         */
        public Builder Undirected()
        {
            directed = false;
            undirected = true;
            return this;
        }

        /**
         * Set the type as mixed.
         * 
         * @return the builder
         */
        public Builder Mixed()
        {
            directed = true;
            undirected = true;
            return this;
        }

        /**
         * Set whether to allow self-loops.
         * 
         * @param value if true self-values are allowed, otherwise not
         * @return the builder
         */
        public Builder AllowSelfLoops(bool value)
        {
            allowSelfLoops = value;
            return this;
        }

        /**
         * Set whether to allow multiple edges.
         * 
         * @param value if true multiple edges are allowed, otherwise not
         * @return the builder
         */
        public Builder AllowMultipleEdges(bool value)
        {
            allowMultipleEdges = value;
            return this;
        }

        /**
         * Set whether the graph will be weighted.
         * 
         * @param value if true the graph will be weighted, otherwise unweighted
         * @return the builder
         */
        public Builder Weighted(bool value)
        {
            weighted = value;
            return this;
        }

        /**
         * Set whether the graph will allow cycles.
         * 
         * @param value if true the graph will allow cycles, otherwise not
         * @return the builder
         */
        public Builder AllowCycles(bool value)
        {
            allowCycles = value;
            return this;
        }

        /**
         * Set whether the graph is modifiable.
         * 
         * @param value if true the graph will be modifiable, otherwise not
         * @return the builder
         */
        public Builder Modifiable(bool value)
        {
            modifiable = value;
            return this;
        }

        /**
         * Build the type.
         * 
         * @return the type
         */
        public DefaultGraphType build()
        {
            return new DefaultGraphType(
                directed, undirected, allowSelfLoops, allowMultipleEdges, weighted, allowCycles,
                modifiable);
        }

    }

}

}
