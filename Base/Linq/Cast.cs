using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Linq
{
    class A
    {
        public void Y()
        {
            Console.WriteLine("A.Y");
        }
    }

    class B : A
    {
        public new void Y()
        {
            Console.WriteLine("B.Y");
        }
    }

    
    [TestClass]
    public class Cast
    {
        [TestMethod]
        public void testCast()
        {
            B[] values = new B[3];
            values[0] = new B();
            values[1] = new B();
            values[2] = new B();

            // Cast all objects to a base type.
            var result = values.Cast<A>();
            foreach (A value in result)
            {
                //不是多态,不会编程B.Y
                value.Y();
                //A.Y
                //A.Y
                //A.Y
            }
        }

    }
}
