using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._08_Composite__组合模式_.Practical
{
    public class Directory : Entry {

        private string name;
        private List<Entry> directory = new List<Entry>();

        public Directory(string name) {
            this.name = name;
        }

        public override string getName() {
            return name;
        }
        public override Entry Add(Entry entry) {
            directory.Add(entry);
            return this;
        }

        public override int getSize() {
            int size = 0;
            foreach(var e in directory) {
                size += e.getSize();
            }
            return size;
        }

        public override void printList(string prefix) {
            Console.WriteLine(prefix + "/" + this);
            foreach(var e in directory) {
                e.printList(prefix+ "/" + name);
            }
        }
    }
}
