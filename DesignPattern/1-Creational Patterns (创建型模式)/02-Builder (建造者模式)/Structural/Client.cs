using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._02_Builder__建造者模式_.Structural
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {
            Builder builder = new ConcreteBuilder();
            Director director = new Director(builder);
            Product product = director.construct();

        }
    }
}
