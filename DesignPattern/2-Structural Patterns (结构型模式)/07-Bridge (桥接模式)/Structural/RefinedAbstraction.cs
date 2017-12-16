using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._07_Bridge__桥接模式_.Structural
{
    /// <summary>
    /// 方法的功能层次的扩展类,新增了两个方法A和B
    /// </summary>
    public class RefinedAbstraction : Abstraction {

        public RefinedAbstraction(Implementor impl) : base(impl) {
        }

        public void refinedMethodA() {
            Console.WriteLine("RefinedAbstraction Method A");
        }

        public void refinedMethodB() {
            Console.WriteLine("RefinedAbstraction Method B");
        }

    }
}
