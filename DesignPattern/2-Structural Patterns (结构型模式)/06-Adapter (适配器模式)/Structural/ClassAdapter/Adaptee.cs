using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Adapter.Structural.ClassAdapter
{
    public class Adaptee {

        public void MethodA() {
            Console.Write("Adaptee MethodA");
        }

        public void MethodB() {
        }

        public void MethodC() {
        }
    }
}
