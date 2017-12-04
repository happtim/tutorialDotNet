using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._13_Chain_of_Responsibility__职责链模式_.Structural
{
    public class ConcreteHandler2 : Handler {
        
        public override bool request(string someTrouble) {
            Console.WriteLine("ConcreteHandler2 Can't Resolve Truoble");
            return false;
        }
    }
}
