using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Behavior.Template
{
    public class SavingAccount : Account
    {
        public override void calculateInterest() {
            Console.WriteLine("按照定期计算利息");
        }
    }
}
