using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._07_Bridge__桥接模式_.Practical
{
    public class Display {
        private DisplayImpl impl;
        public Display(DisplayImpl impl) {
            this.impl = impl;
        }

        public void open() {
            impl.rawOpen();
        }

        public void print() {
            impl.rawPrint();
        }

        public void close() {
            impl.rawClose();
        }

        public void display() {
            open();
            print();
            close();
        }
    }

}
