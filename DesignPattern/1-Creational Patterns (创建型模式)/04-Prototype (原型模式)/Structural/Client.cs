using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._04_Prototype__原型模式_.Structural
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {
            Prototype p1 = new ConcretePrototype("Tim");
            Prototype p2 = p1.createClone();
            p2.call("sam");
        }
    }
}
