using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._19_Observer__观察者模式_.Structural
{
    public class ConcreteObserver2 : Observer
    {
        public override void update(Subject subject) {
            Console.WriteLine("Observer 2 Watch subject Status Changed");
        }
    }
}
