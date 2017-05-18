using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Threads
{
    [TestClass()]
    public class Lock
    {
        private static object _lock = new object();

        public void funciton1() {
            lock (_lock) {
                function2();
            }
        }

        public void function2() {
            lock (_lock) {
                Console.WriteLine("锁住没有");
            }
        }

        [TestMethod()]
        public void test() {
            funciton1();
        }
    }
}
