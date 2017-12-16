using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._07_Bridge__桥接模式_.Practical
{
    public abstract class DisplayImpl {
        public abstract void rawOpen();
        public abstract void rawPrint();
        public abstract void rawClose();
    }
}
