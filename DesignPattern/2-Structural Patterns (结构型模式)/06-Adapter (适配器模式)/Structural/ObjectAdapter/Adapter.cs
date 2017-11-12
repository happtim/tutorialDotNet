using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Adapter.Structural.ObjectAdapter
{
    public class Adapter :Target {


        private Adaptee adaptee = new Adaptee();

        public override void targetMethod1() {
            this.adaptee.MethodA();
        }

        public override void targetMethod2() {
            this.adaptee.MethodB();
        }


    }
}
