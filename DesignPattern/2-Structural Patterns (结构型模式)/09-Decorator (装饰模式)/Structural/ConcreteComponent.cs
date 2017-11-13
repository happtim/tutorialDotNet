using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._09_Decorator__装饰模式_.Structural
{
    public class ConcreteComponent : Component
    {
        public override void Method1() {
            Console.WriteLine("ConcreteComponent Method1");
        }

        public override void Method2() {
            Console.WriteLine("ConcreteComponent Method2");
        }
    }
}
