using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._19_Observer__观察者模式_.Practical
{
    [TestClass]
    public class Client
    {

        [TestMethod]
        public void test() {
            NumberGenerator generator = new RandomNumberGenerator();
            Observer observer1 = new GraphObserver();
            Observer observer2 = new DigitObserver();

            generator.addObserver(observer1);
            generator.addObserver(observer2);

            generator.execute();


        }
    }
}
