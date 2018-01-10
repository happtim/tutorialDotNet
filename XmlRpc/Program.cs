using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CookComputing.XmlRpc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XmlRpc
{
    [TestClass]
    public class Program
    {
        static void Main(string[] args)
        {
        }

        [TestMethod]
        public void TestClient() {
            fandai fd = XmlRpcProxyGen.Create<fandai>();
            int a = fd.findai(1);
            Console.WriteLine(a);
        }

    }
}
