using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._01_Abstract_Factory__抽象工厂模式_.Structural
{
    [TestClass]
    public class Main {

        [TestMethod]
        public void Test() {
            AbstractFactory factory1 = new ConcreteFactory1();
            Client c1 = new Client(factory1);
            c1.Run();


            AbstractFactory factory2 = new ConcreteFactory2();
            Client c2 = new Client(factory2);
            c2.Run();

        }
    }
}
