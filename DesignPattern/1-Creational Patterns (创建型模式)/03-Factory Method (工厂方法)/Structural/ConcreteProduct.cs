using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._03_Factory_Method__工厂方法_.Structural
{
    public class ConcreteProduct : Product
    {
        public override void method1() {
            Console.WriteLine("ConcreteProduct method1");
        }

        public override void method2() {
            Console.WriteLine("ConcreteProduct method2");
        }

        public override void method3() {
            Console.WriteLine("ConcreteProduct method3");
        }
    }
}
