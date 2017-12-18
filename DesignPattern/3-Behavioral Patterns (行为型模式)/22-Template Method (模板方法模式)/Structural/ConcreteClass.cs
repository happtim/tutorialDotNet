using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._22_Template_Method__模板方法模式_.Structural
{
    public class ConcreteClass : AbstractClass
    {
        public override void method1() {
            Console.WriteLine("ConcreteClass Implement Method1");
        }

        public override void method2() {
            Console.WriteLine("ConcreteClass Implement Method2");
        }

        public override void method3() {
            Console.WriteLine("ConcreteClass Implement Method3");
        }
    }
}
