using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._19_Observer__观察者模式_.Practical
{
    public class RandomNumberGenerator : NumberGenerator {

        private int number;

        public override int Number { get { return number; } }

        public override void execute() {

            for(int i = 0; i< 10; i++) {
                number = (new Random()).Next(50);
                notifyObservers();
            }
        }

    }
}
