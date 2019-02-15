using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Collections
{
    /**
     * Helper for efficiently representing small sets whose elements are known to be unique by
     * construction, implying we don't need to enforce the uniqueness property in the data structure
     * itself. Use with caution.
     *
     * <p>
     * Note that for equals/hashCode, the class implements the Set behavior (unordered), not the list
     * behavior (ordered); the fact that it subclasses ArrayList should be considered an implementation
     * detail.
     * 
     * @param <E> the element type
     *
     * @author John V. Sichi
     */
    public class ArrayUnenforcedSet<E> : List<E>// HashSet<E>
    {

        /**
         * Constructs a new empty set
         */
        public ArrayUnenforcedSet()
            : base()
        {
        }

        /**
         * Constructs a set containing the elements of the specified collection.
         *
         * @param c the collection whose elements are to be placed into this set
         * @throws NullPointerException if the specified collection is null
         */
        public ArrayUnenforcedSet(IEnumerable<E> c)
            : base(c)
        {
        }

        /**
         * Constructs an empty set with the specified initial capacity.
         *
         * @param n the initial capacity of the set
         * @throws IllegalArgumentException if the specified initial capacity is negative
         */
        public ArrayUnenforcedSet(int n)
            : base(n)
        {
        }


        /*
    @Override
    public boolean equals(Object o)
    {
        return new SetForEquality().equals(o);
    }

    @Override
    public int hashCode()
    {
        return new SetForEquality().hashCode();
    }

    private class SetForEquality extends AbstractSet<E>
    {
        @Override
        public Iterator<E> iterator()
    {
        return ArrayUnenforcedSet.this.iterator();
    }

    @Override
        public int size()
    {
        return ArrayUnenforcedSet.this.size();
    }
        */
        //}
    }

    // End ArrayUnenforcedSet.java

}
