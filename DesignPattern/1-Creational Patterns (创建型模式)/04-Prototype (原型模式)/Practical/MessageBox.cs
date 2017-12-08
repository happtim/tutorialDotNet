using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._04_Prototype__原型模式_.Practical
{
    public class MessageBox : Product {
        private char decochar;
        public MessageBox(char decochar) {
            this.decochar = decochar;
        }

        public object Clone() {
            return this.MemberwiseClone();
        }

        public void use(string s) {
            int length = s.Length;
            for(int i = 0; i< length + 4; i++) {
                Console.Write(decochar);
            }
            Console.WriteLine();
            Console.WriteLine(decochar + " " + s + " " + decochar);
            for(int i = 0; i< length + 4; i++) {
                Console.Write(decochar);
            }
            Console.WriteLine();
        }
    }
}
