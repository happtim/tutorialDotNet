using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._22_Template_Method__模板方法模式_.Structural
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {
            AbstractClass absClass = new ConcreteClass();
            absClass.templateMthod();
        }
    }
}
