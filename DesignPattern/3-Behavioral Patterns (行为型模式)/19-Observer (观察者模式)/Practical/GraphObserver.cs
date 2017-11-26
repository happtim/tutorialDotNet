using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._19_Observer__观察者模式_.Practical
{
    public class GraphObserver : Observer
    {
        public void update(NumberGenerator numberGenerator) {
            Console.Write("GraphObserver:");
            int count = numberGenerator.Number;
            for(int i = 0; i< count; i++) {
                Console.Write("*");
            }
            Console.WriteLine();
            Thread.Sleep(100);

        }
    }
}
