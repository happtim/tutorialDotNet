using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpGuide._04_Delegates
{
    [TestClass]
    public class TestLog {

        public static void LogToConsole(string message)
        {
            Console.Error.WriteLine(message);
        }

        [TestMethod]
        public void Test() {
            var file = new FileLogger("log.txt");
            Logger.WriteMessage += LogToConsole;

            Logger.LogMessage(Severity.Error, "test", "hello world");

        }
    }
}
