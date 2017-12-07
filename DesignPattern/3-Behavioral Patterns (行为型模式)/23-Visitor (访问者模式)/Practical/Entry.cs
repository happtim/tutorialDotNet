using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._23_Visitor__访问者模式_.Practical
{
    public abstract class Entry : Element {

        public abstract void accept(Visitor visitor); 
            //visitor.visit(this);
        

        public Entry add(Entry entry) {
            throw new NotImplementedException();
        }

        public abstract string getName();

        public abstract int getSize();

        public override string ToString() {
            return getName() + " (" + getSize() + ")";
        }


    }
}
