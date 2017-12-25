using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._08_Composite__组合模式_.Practical
{
    public abstract class Entry {
        public abstract string getName();
        public abstract int getSize();

        public virtual Entry Add(Entry entry) {
            throw new NotImplementedException();
        }

        public void printList() {
            printList("");
        }

       public abstract void printList(string prefix);

        public override string ToString() {
            return getName() + "(" + getSize() + ")";
        }

    }
}
