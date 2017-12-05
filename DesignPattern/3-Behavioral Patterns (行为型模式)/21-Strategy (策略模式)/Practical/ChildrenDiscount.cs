using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._21_Strategy__策略模式_.Practical
{
    public class ChildrenDiscount : Discount
    {
        public override double calculate(double price) {
            Console.WriteLine("学生票:");
            return price -10;
        }
    }
}
