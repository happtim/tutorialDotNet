using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._08_Composite__组合模式_.Structural
{
    public class Composite : Component {

        private List<Component> list = new List<Component>();

        public override void add(Component c) {
            list.Add(c);
        }

        public override Component getChild(int i) {
            return list[i];
        }

        public override void method1() {
            foreach(var c in list) {
                c.method1();
            }
        }

        public override void method2() {
            foreach(var c in list) {
                c.method2();
            }
        }

        public override void remove(Component c) {
            list.Remove(c);
        }
    }
}
