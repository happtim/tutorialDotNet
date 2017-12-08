using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._04_Prototype__原型模式_.Practical
{
    public class UnderlinePen : Product {
        private char ulchar;
        public UnderlinePen(char ulchar) {
            this.ulchar = ulchar;
        }

        public object Clone() {
            return this.MemberwiseClone();
        }

        public void use(string s) {
            int length = s.Length;
            Console.WriteLine("\"" + s + "\"");
            Console.Write(" ");
            for(int i = 0; i< length; i++) {
                Console.Write(ulchar);
            }
            Console.WriteLine();
        }
    }
}
