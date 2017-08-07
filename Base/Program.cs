using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    class Program
    {
        static void Main(string[] args) {

            Keywords.LockTest lockTest = new Keywords.LockTest();
            lockTest.testLock();
        }
    }
}
