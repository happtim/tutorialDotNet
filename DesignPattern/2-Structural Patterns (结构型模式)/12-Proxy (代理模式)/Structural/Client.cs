using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._12_Proxy__代理模式_.Structural
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {

            Subject s = new Proxy();
            s.SomeMethod();
            s.SomeMethod2();
            s.Request();
               
        }
    }
}
