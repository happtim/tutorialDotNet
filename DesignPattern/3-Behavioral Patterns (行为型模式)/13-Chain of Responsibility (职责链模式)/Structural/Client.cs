using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._13_Chain_of_Responsibility__职责链模式_.Structural
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();

            h2.setNext(h1);

            h2.resolve("some thing");

        }
    }
}
