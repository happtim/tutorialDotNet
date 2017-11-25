using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._17_Mediator__中介者模式_.Structural
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test(){

            Mediator mediator = new ConcreteMediator();

            ConcreteColleague1 c1 = new ConcreteColleague1();
            c1.SetMediator(mediator);
            mediator.RegisterColleagues(c1);

            ConcreteColleague2 c2 = new ConcreteColleague2();
            c2.SetMediator(mediator);
            mediator.RegisterColleagues(c2);

            c2.NotifyMediator();

        }
    }

}
