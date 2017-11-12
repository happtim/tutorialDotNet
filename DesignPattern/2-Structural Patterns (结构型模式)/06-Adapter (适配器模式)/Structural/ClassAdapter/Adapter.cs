using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Adapter.Structural.ClassAdapter
{
    public class Adapter : Adaptee, ITarget
    {
        public void targetMethod1() {
            MethodA();
        }

        public void targetMethod2() {
            MethodB();
        }
    }
}
