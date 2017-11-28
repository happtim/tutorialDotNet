using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._14_Command__命令模式_.Structural
{
    [TestClass]
    public class Client
    {
        [TestMethod]
        public void test() {
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker(command);

            invoker.call();

        }
    }
}
