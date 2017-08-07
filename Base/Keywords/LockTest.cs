using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Keywords
{
    [TestClass]
    public class LockTest {

        private Object _lock = new Object();

        public void Lock2(string name) {

            lock (_lock) {
                Console.WriteLine("Lock are called by {0}",name);
            }
        }

        [TestMethod]
        public void testLock() {


            new Thread(delegate () {

                Thread.CurrentThread.Name = "Thread1";

                while (true) {
                    lock (_lock) {
                        Lock2(Thread.CurrentThread.Name);
                    }
                }
            }).Start();


            new Thread(delegate () {

                Thread.CurrentThread.Name = "Thread2";

                while (true) {
                    Lock2(Thread.CurrentThread.Name);
                }
            }).Start();

            Console.ReadLine();

        }
    }
}
