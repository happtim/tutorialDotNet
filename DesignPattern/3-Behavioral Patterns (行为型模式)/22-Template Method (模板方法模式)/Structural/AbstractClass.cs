using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._22_Template_Method__模板方法模式_.Structural
{
    public abstract class AbstractClass {
        public abstract void method1();
        public abstract void method2();
        public abstract void method3();

        public void templateMthod() {
            Console.WriteLine("Template Method");
            method1();
            method2();
            method3();
        } 
    }
}
