using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Algorithm.Graph;

namespace Algorithm.Builder
{
    /**
     * A builder class for {@link Graph}.
     * 
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     * @param <G> type of the resulting graph
     * 
     * @author Andrew Chen
     */
    public class GraphBuilder<V, E, G> : AbstractGraphBuilder<V, E, G, GraphBuilder<V, E, G>>
        where G : Graph<V,E>
{
    /**
     * Creates a builder based on {@code baseGraph}. {@code baseGraph} must be mutable.
     *
     * <p>
     * The recommended way to use this constructor is: {@code new
     * GraphBuilderBase<...>(new YourGraph<...>(...))}.
     *
     * <p>
     * NOTE: {@code baseGraph} should not be an existing graph. If you want to add an existing graph
     * to the graph being built, you should use the {@link #addVertex(Object)} method.
     *
     * @param baseGraph the graph object to base building on
     */
    public GraphBuilder(G baseGraph)
        :base(baseGraph)
    {
    }

    protected override GraphBuilder<V, E, G> self()
    {
        return this;
    }

}

}
