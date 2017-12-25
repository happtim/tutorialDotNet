using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._08_Composite__组合模式_.Structural
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {
            Component c1 = new Left();
            Component c2 = new Left();

            Component composite = new Composite();
            composite.add(c1);
            composite.add(c2);

            composite.method1();
        }
    }
}
