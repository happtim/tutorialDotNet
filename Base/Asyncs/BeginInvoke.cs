using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Asyncs
{

    public class AsyncDemo {

        // The method to be executed asynchronously.
        public string TestMethod(int callDuration, out int threadId)
        {
            Console.WriteLine("Test method begins.");
            Thread.Sleep(callDuration);
            threadId = Thread.CurrentThread.ManagedThreadId;
            return String.Format("My call time was {0}.", callDuration.ToString());
        }
    }
    // The delegate must have the same signature as the method
    // it will call asynchronously.
    public delegate string AsyncMethodCaller(int callDuration, out int threadId);

    [TestClass]
    public class BeginInvoke {

        [TestMethod]
        public void Test() {

            // The asynchronous method puts the thread id here.
            int threadId;

            // Create an instance of the test class.
            AsyncDemo ad = new AsyncDemo();

            // Create the delegate.
            AsyncMethodCaller caller = new AsyncMethodCaller(ad.TestMethod);

            // Initiate the asychronous call.
            IAsyncResult result = caller.BeginInvoke(3000,
                out threadId, null, null);

            Thread.Sleep(0);
            Console.WriteLine("Main thread {0} does some work.",
                Thread.CurrentThread.ManagedThreadId);

            // Call EndInvoke to wait for the asynchronous call to complete,
            // and to retrieve the results.
            //两种获取值得方式,一个使用out一个使用返回值
            string returnValue = caller.EndInvoke(out threadId, result);

            Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".",
                    threadId, returnValue);
        }
      
    }

}
