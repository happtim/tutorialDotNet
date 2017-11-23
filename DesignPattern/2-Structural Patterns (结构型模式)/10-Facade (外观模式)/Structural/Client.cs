using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._10_Facade__外观模式_.Structural
{
    [TestClass]
    public class Client
    {
        [TestMethod]
        public void Test() {

            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();
        }
    }
}
