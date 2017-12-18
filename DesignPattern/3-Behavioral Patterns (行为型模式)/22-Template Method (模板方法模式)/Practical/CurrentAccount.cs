using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Behavior.Template
{
    class CurrentAccount : Account
    {
        public override void calculateInterest() {
            Console.WriteLine("按照活期计算利息");
        }
    }
}
