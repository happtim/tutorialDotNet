using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Generics
{
    [TestClass]
    public class OperatorEqual {

        public class A {
            public string Name { get; set; }

            public static bool Equals(A a1,A a2) {
                return a1.Name == a2.Name;
            }

            public static bool operator == (A a1 , A a2) {
                return A.Equals(a1, a2);
            }
            public static bool operator != (A a1 , A a2) {
                return !A.Equals(a1, a2);
            }
        }

        public class B : A { }


        public static bool OpTest<T>(T s, T t) where T : class {
            return s == t;
        }

        public static bool OpTest2<T>(T s, T t) where T : A {
            return s == t;
        }

        [TestMethod]
        public void Test() {
            string s1 = "target";
            System.Text.StringBuilder sb = new System.Text.StringBuilder("target");
            string s2 = sb.ToString();
            Assert.AreEqual(OpTest<string>(s1, s2), false);
        }

        [TestMethod]
        public void Test2()
        {
            A a = new A { Name = "Tim" };
            B b = new B { Name = "Tim" };
            Assert.AreEqual(OpTest2<A>(a, b), true);
        }

    }
}
