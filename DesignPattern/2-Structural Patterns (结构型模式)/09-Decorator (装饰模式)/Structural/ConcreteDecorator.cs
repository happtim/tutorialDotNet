using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._09_Decorator__装饰模式_.Structural
{
    public class ConcreteDecorator : Decorator {

        public ConcreteDecorator(Component component):base(component){

        }

        public override void Method1() {
            component.Method1();
            Console.WriteLine("ConcreteDecorator Method1");
        }

        public override void Method2() {
            component.Method2();
            Console.WriteLine("ConcreteDecorator Method2");
        }
    }
}
