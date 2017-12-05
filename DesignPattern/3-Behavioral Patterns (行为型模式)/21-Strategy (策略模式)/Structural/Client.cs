using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._21_Strategy__策略模式_.Structural
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {
            Context context = new Context();
            Strategy strategy = new ConcreteStrategyB();
            context.setStrategy(strategy);
            context.algorithm();
        }
    }
}
