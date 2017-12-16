using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._07_Bridge__桥接模式_.Structural
{

    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {
            Abstraction abst = new RefinedAbstraction(new ConcreteImplementor());
            abst.method1();
            ((RefinedAbstraction)abst).refinedMethodA();
        }
    }
}
