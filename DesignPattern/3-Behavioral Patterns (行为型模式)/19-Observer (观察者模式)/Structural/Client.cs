using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._19_Observer__观察者模式_.Structural
{
    [TestClass]
    public class Client
    {

        [TestMethod]
        public void test() {

            Subject subject = new ConcreteSubject();
            Observer observer = new ConcreteObserver();
            Observer observer2 = new ConcreteObserver2();
            subject.addObserver(observer);
            subject.addObserver(observer2);
            subject.getSubjectStatus();

        }
    }
}
