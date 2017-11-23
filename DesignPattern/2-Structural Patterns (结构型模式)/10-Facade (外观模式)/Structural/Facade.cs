using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._10_Facade__外观模式_.Structural
{
    public class Facade {

        private SubSystemOne one;
        private SubSystemTwo two;
        private SubSystemThree three;
        private SubSystemFour four;


        public Facade() {
            one = new SubSystemOne();
            two = new SubSystemTwo();
            three = new SubSystemThree();
            four = new SubSystemFour();
        }

        public void MethodA() {
            Console.WriteLine("Facede MethodA");
            one.MethodOne();
            two.MethodTwo();
            four.MethodFour();
        }

        public void MethodB() {
            Console.WriteLine("Facede MethodB");
            two.MethodTwo();
            three.MethodThree();
        }

    }
}
