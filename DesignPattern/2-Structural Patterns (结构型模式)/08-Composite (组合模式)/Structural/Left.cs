using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._08_Composite__组合模式_.Structural
{
    public class Left : Component
    {
        public override void add(Component c) {
            throw new NotImplementedException();
        }

        public override Component getChild(int i) {
            throw new NotImplementedException();
        }

        public override void method1() {
            Console.WriteLine("Left method1");
        }

        public override void method2() {
            Console.WriteLine("Left method2");
        }

        public override void remove(Component c) {
            throw new NotImplementedException();
        }
    }
}
