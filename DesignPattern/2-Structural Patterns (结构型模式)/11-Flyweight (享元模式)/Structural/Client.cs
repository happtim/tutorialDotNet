using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._11_Flyweight__享元模式_.Structural
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {

            FlyweightFactory factory = new FlyweightFactory();
            Flyweight a = factory.getFlyweight("aaa");
            Flyweight a2 = factory.getFlyweight("aaa");

            Assert.AreEqual(a, a2);

        }
    }
}
