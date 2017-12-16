using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._07_Bridge__桥接模式_.Practical
{
    public class CountDisplay : Display {

        public CountDisplay(DisplayImpl impl) : base(impl) {

        }

        public void multiDisplay(int times) {
            open();
            for(int i = 0; i< times; i++) {
                print();
            }
            close();
        }
    }
}
