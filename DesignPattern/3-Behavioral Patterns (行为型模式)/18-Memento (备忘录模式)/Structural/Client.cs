using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._18_Memento__备忘录模式_.Structural
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void test() {
            Caretaker caretaker = new Caretaker();
            caretaker.setMemento(new Memento(new Originator() {state = "state1" }));
            Originator o = new Originator();
            o.restoreMemento(caretaker.getMemento());
        }

    }
}
