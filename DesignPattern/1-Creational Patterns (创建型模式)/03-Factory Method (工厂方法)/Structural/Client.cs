using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._03_Factory_Method__工厂方法_.Structural
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {

            Creator creator = new ConcreteCreator();
            Product product  = creator.factoryMethod();
            product.method1();

        }
    }
}
