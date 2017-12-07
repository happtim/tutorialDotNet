using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._23_Visitor__访问者模式_.Structural
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {

            ObjectStructure os = new ObjectStructure();
            os.addElement(new ConcreteElementA());
            os.addElement(new ConcreteElementB());
            os.accept(new ConcreteVisitorA());
            os.accept(new ConcreteVisitorB());

        }
    }
}
