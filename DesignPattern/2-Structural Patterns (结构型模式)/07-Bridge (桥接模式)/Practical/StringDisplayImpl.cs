using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._07_Bridge__桥接模式_.Practical
{
    public class StringDisplayImpl : DisplayImpl {
        private string str;
        private int width;

        public StringDisplayImpl(string str) {
            this.str = str;
            this.width = str.Length;
        }

        public override void rawClose() {
            printLine();
        }

        public override void rawOpen() {
            printLine();
        }

        public override void rawPrint() {
            Console.WriteLine("|" + str + "|");
        }

        public void printLine() {
            Console.Write("+");
            for(int i = 0; i< width; i++) {
                Console.Write("-");
            }
            Console.WriteLine("+");

        }
    }
}
