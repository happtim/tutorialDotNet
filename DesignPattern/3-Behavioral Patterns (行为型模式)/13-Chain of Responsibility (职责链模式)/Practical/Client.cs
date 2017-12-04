using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._13_Chain_of_Responsibility__职责链模式_.Practical
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {
            Support alice = new NoSupport("Alice");
            Support bob = new LimitSupport("Bob", 100);
            Support charlie = new SpecialSupport("Charlie", 429);
            Support diana = new LimitSupport("Diana", 200);
            Support elmo = new OddSupport("Elmo");
            Support fred = new LimitSupport("Fred", 300);

            alice.setNext(bob).setNext(charlie).setNext(diana).setNext(elmo).setNext(fred);

            for(int i = 0; i< 500;i += 33) {
                alice.support(new Trouble(i));
            }
        }
    }
}
