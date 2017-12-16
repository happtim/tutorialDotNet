using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._07_Bridge__桥接模式_.Structural
{
    /// <summary>
    /// 类实现层次的实现
    /// </summary>
    class ConcreteImplementor : Implementor {

        public void implMethodX() {
            Console.WriteLine("ConcreteImplementor Method X");
        }

        public void implMethodY() {
            Console.WriteLine("ConcreteImplementor Method Y");
        }
    }
}
