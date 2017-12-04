using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._13_Chain_of_Responsibility__职责链模式_.Practical
{
    public abstract class Support {
        private Support next;
        private string name;

        public Support(string name) {
            this.name = name;
        }

        public Support setNext(Support next) {
            this.next = next;
            return next;
        }

        public void support(Trouble trouble) {
            if (resolve(trouble)) {
                done(trouble);
            } else if(next != null) {
                next.support(trouble);
            } else {
                fail(trouble);
            }
        }

        protected abstract bool resolve(Trouble trouble);

        protected void done(Trouble trouble) {
            Console.WriteLine(trouble + "is resolve by " + this + ".");
        }
        protected void fail (Trouble trouble) {
            Console.WriteLine(trouble + "cannot be resolved.");
        }

        public override string ToString() {
            return "[" + name +"]";
        }


    }
}
