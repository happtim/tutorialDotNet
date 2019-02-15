using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Algorithm.Graph;
using Algorithm.Specifics;
using Algorithm.Collections;

namespace Algorithm.Specifics
{

    /**
     * Plain implementation of DirectedSpecifics. This implementation requires the least amount of
     * memory, at the expense of slow edge retrievals. Methods which depend on edge retrievals, e.g.
     * getEdge(V u, V v), containsEdge(V u, V v), addEdge(V u, V v), etc may be relatively slow when the
     * average degree of a vertex is high (dense graphs). For a fast implementation, use
     * {@link FastLookupDirectedSpecifics}.
     * 
     * @param <V> the graph vertex type
     * @param <E> the graph edge type
     *
     * @author Barak Naveh
     * @author Joris Kinable
     */
    public class DirectedSpecifics<V, E> : Specifics<V, E> 
{

    protected AbstractBaseGraph<V, E> abstractBaseGraph;
    protected Dictionary<V, DirectedEdgeContainer<V, E>> vertexMapDirected;
    protected EdgeSetFactory<V, E> edgeSetFactory;

    /**
     * Construct a new directed specifics.
     * 
     * @param abstractBaseGraph the graph for which these specifics are for
     */
    public DirectedSpecifics(AbstractBaseGraph<V, E> abstractBaseGraph)
        :this(abstractBaseGraph, 
             new Dictionary<V, DirectedEdgeContainer<V, E>>(), 
             new ArrayUnenforcedSetEdgeSetFactory<V,E>())
    {
    }

    /**
     * Construct a new directed specifics.
     * 
     * @param abstractBaseGraph the graph for which these specifics are for
     * @param vertexMap map for the storage of vertex edge sets
     */
    public DirectedSpecifics( AbstractBaseGraph<V, E> abstractBaseGraph, 
        Dictionary<V, DirectedEdgeContainer<V, E>> vertexMap)
        :this(abstractBaseGraph, vertexMap, new ArrayUnenforcedSetEdgeSetFactory<V,E>())
    {
    }

    /**
     * Construct a new directed specifics.
     * 
     * @param abstractBaseGraph the graph for which these specifics are for
     * @param vertexMap map for the storage of vertex edge sets
     * @param edgeSetFactory factory for the creation of vertex edge sets
     */
    public DirectedSpecifics(
        AbstractBaseGraph<V, E> abstractBaseGraph, 
        Dictionary<V, DirectedEdgeContainer<V, E>> vertexMap,
        EdgeSetFactory<V, E> edgeSetFactory)
    {
        this.abstractBaseGraph = abstractBaseGraph;
        this.vertexMapDirected = vertexMap;
        this.edgeSetFactory = edgeSetFactory;
    }

    /**
     * {@inheritDoc}
     */
    public override void addVertex(V v)
    {
        // add with a lazy edge container entry
        vertexMapDirected[v] =  null;
    }

    /**
     * {@inheritDoc}
     */
    public override HashSet<V> getVertexSet()
    {
            return new HashSet<V>(vertexMapDirected.Keys);
    }

    /**
     * {@inheritDoc}
     */
    public override HashSet<E> getAllEdges(V sourceVertex, V targetVertex)
    {
        List<E> edges = null;

        if (abstractBaseGraph.containsVertex(sourceVertex)
            && abstractBaseGraph.containsVertex(targetVertex))
        {
            edges = new ArrayUnenforcedSet<E>();

            DirectedEdgeContainer<V, E> ec = getEdgeContainer(sourceVertex);

            foreach (E e in ec.outgoing)
            {
                if (abstractBaseGraph.getEdgeTarget(e).Equals(targetVertex))
                {
                    edges.Add(e);
                }
            }
        }

        return new HashSet<E>( edges);
    }

    /**
     * {@inheritDoc}
     */
    public override E getEdge(V sourceVertex, V targetVertex)
    {
        if (abstractBaseGraph.containsVertex(sourceVertex)
            && abstractBaseGraph.containsVertex(targetVertex))
        {
            DirectedEdgeContainer<V, E> ec = getEdgeContainer(sourceVertex);

            foreach (E e in ec.outgoing)
            {
                if (abstractBaseGraph.getEdgeTarget(e).Equals(targetVertex))
                {
                    return e;
                }
            }
        }

        return default(E);
    }

    /**
     * {@inheritDoc}
     */
    public override void addEdgeToTouchingVertices(E e)
    {
        V source = abstractBaseGraph.getEdgeSource(e);
        V target = abstractBaseGraph.getEdgeTarget(e);

        getEdgeContainer(source).addOutgoingEdge(e);
        getEdgeContainer(target).addIncomingEdge(e);
    }

    /**
     * {@inheritDoc}
     */
    public override int degreeOf(V vertex)
    {
        return inDegreeOf(vertex) + outDegreeOf(vertex);
    }

    /**
     * {@inheritDoc}
     */
    public override HashSet<E> edgesOf(V vertex)
    {
        ArrayUnenforcedSet<E> inAndOut = new ArrayUnenforcedSet<E>(getEdgeContainer(vertex).incoming);
        
        inAndOut.AddRange(getEdgeContainer(vertex).outgoing);

        // we have two copies for each self-loop - remove one of them.
        if (abstractBaseGraph.isAllowingLoops())
        {
            HashSet<E> loops = getAllEdges(vertex, vertex);

            for (int i = 0; i < inAndOut.Count;)
            {
                E e = inAndOut[i];

                if (loops.Contains(e))
                {
                    inAndOut.RemoveAt(i);
                    loops.Remove(e); // so we remove it only once
                }
                else
                {
                    i++;
                }
            }
        }

        return new HashSet<E>(inAndOut);
    }

    /**
     * {@inheritDoc}
     */
    public override int inDegreeOf(V vertex)
    {
        return getEdgeContainer(vertex).incoming.Count;
    }

    /**
     * {@inheritDoc}
     */
    public override HashSet<E> incomingEdgesOf(V vertex)
    {
        return getEdgeContainer(vertex).getUnmodifiableIncomingEdges();
    }

    /**
     * {@inheritDoc}
     */
    public override int outDegreeOf(V vertex)
    {
        return getEdgeContainer(vertex).outgoing.Count;
    }

    /**
     * {@inheritDoc}
     */
    public override HashSet<E> outgoingEdgesOf(V vertex)
    {
        return getEdgeContainer(vertex).getUnmodifiableOutgoingEdges();
    }

    /**
     * {@inheritDoc}
     */
    public override void removeEdgeFromTouchingVertices(E e)
    {
        V source = abstractBaseGraph.getEdgeSource(e);
        V target = abstractBaseGraph.getEdgeTarget(e);

        getEdgeContainer(source).removeOutgoingEdge(e);
        getEdgeContainer(target).removeIncomingEdge(e);
    }

    /**
     * A lazy build of edge container for specified vertex.
     *
     * @param vertex a vertex in this graph.
     *
     * @return an edge container
     */
    protected DirectedEdgeContainer<V, E> getEdgeContainer(V vertex)
    {
        DirectedEdgeContainer<V, E> ec = vertexMapDirected[vertex];

        if (ec == null)
        {
            ec = new DirectedEdgeContainer<V,E> (edgeSetFactory, vertex);
            vertexMapDirected[vertex] =  ec;
        }

        return ec;
    }
}

}
