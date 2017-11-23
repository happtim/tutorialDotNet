using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._10_Facade__外观模式_.Structural
{
    public class SubSystemOne {
        public void MethodOne() {
            Console.WriteLine("SubSystemOne Method");
        }
    }

    public class SubSystemTwo {
        public void MethodTwo() {
            Console.WriteLine("SubSystemTwo Method");
        }
    }

    public class SubSystemThree {
        public void MethodThree() {
            Console.WriteLine("SubSystemThree Method");
        }
    }

    public class SubSystemFour {
        public void MethodFour() {
            Console.WriteLine("SubSystemFour Method");
        }
    }
}
