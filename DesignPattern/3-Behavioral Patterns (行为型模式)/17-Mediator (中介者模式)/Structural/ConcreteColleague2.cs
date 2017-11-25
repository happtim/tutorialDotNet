using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._17_Mediator__中介者模式_.Structural
{
    public class ConcreteColleague2 : Colleague
    {
        public override void ControlColleague() {
            Console.WriteLine("Colleague2 Change");
        }
    }
}
