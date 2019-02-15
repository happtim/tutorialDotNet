
using System;

/**
 * Implements a node of the Fibonacci heap. It holds the information necessary for maintaining the
 * structure of the heap. It also holds the reference to the key value (which is used to determine
 * the heap structure).
 * 
 * @param <T> node data type
 *
 * @author Nathan Fiedler
 */
public class FibonacciHeapNode<T>
{
    /**
     * Node data.
     */
    T data;

    /**
     * first child node
     */
    public FibonacciHeapNode<T> child;

    /**
     * left sibling node
     */
    public FibonacciHeapNode<T> left;

    /**
     * parent node
     */
    public FibonacciHeapNode<T> parent;

    /**
     * right sibling node
     */
    public FibonacciHeapNode<T> right;

    /**
     * true if this node has had a child removed since this node was added to its parent
     */
    public bool mark;

    /**
     * key value for this node
     */
    public double key;

    /**
     * number of children of this node (does not count grandchildren)
     */
    public int degree;

    /**
     * Constructs a new node.
     *
     * @param data data for this node
     */
    public FibonacciHeapNode(T data)
    {
        this.data = data;
    }

    /**
     * Obtain the key for this node.
     *
     * @return the key
     */
    public double getKey()
    {
        return key;
    }

    /**
     * Obtain the data for this node.
     * 
     * @return the data
     */
    public  T getData()
    {
        return data;
    }

    /**
     * Return the string representation of this object.
     *
     * @return string representing this object
     */
    public override String ToString()
    {
        return key.ToString();
    }

    // toString
}

// End FibonacciHeapNode.java
