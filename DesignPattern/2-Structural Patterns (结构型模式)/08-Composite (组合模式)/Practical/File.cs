using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._08_Composite__组合模式_.Practical
{
    public class File : Entry {

        private string name;
        private int size;

        public File(string name,int size) {
            this.name = name;
            this.size = size;
        }

        public override string getName() {
            return name;
        }

        public override int getSize() {
            return size;
        }

        public override void printList(string prefix) {
            Console.WriteLine(prefix + "/" + this);
        }
    }
}
