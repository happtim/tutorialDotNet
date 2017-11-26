using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._19_Observer__观察者模式_.Practical
{
    public class DigitObserver : Observer
    {
        public void update(NumberGenerator numberGenerator) {
            Console.WriteLine("DigitObserver:" + numberGenerator.Number);
            Thread.Sleep(100);
        }
    }
}
