using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._07_Bridge__桥接模式_.Practical
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {
            Display d1 = new Display(new StringDisplayImpl("Hello China."));
            Display d2 = new Display(new StringDisplayImpl("Hello World."));
            CountDisplay d3 = new CountDisplay(new StringDisplayImpl("Hello Universe."));

            d1.display();
            d2.display();
            d3.display();

            d3.multiDisplay(3);
        }
    }
}
