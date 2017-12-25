using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._08_Composite__组合模式_.Structural
{
    public abstract class Component {
        public abstract void method1();
        public abstract void method2();
        public abstract void add(Component c);
        public abstract void remove(Component c);
        public abstract Component getChild(int i);
    }
}
