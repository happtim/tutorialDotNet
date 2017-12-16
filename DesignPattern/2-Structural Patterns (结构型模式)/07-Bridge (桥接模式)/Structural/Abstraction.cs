using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._07_Bridge__桥接模式_.Structural
{
    public abstract class Abstraction {
        private Implementor impl;
        public Abstraction(Implementor impl) {
            this.impl = impl;
        }

        public void method1() {
            impl.implMethodX();
        }
        public void method2() {
            impl.implMethodY();
        }

    }
}
