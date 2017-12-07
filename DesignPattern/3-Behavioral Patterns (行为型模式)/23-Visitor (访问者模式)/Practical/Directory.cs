using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._23_Visitor__访问者模式_.Practical
{
    public class Directory : Entry,IEnumerable {

        private string name;
        private List<Entry> dir = new List<Entry>();

        public Directory(string name) {
            this.name = name;
        }

        public override void accept(Visitor visitor) {
            visitor.visit(this);
        }

        public new Entry add(Entry entry) {
            dir.Add(entry);
            return this;
        }

        public override string getName() {
            return name;
        }

        public override int getSize() {
            int size = 0;
            foreach(var file in dir) {
                size += file.getSize();
            }
            return size;
        }

        public IEnumerator GetEnumerator() {
            return dir.GetEnumerator();
        }
    }
}
