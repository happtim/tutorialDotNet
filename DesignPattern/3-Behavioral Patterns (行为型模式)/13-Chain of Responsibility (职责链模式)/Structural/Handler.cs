using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._13_Chain_of_Responsibility__职责链模式_.Structural
{
    public abstract class Handler {

        private Handler next;

        public void setNext(Handler handler) {
            next= handler;
        }

        public void resolve(string someTrouble) {
            if (request(someTrouble)) {
                //done
            } else {
                next.request(someTrouble);
            }
        }

        public abstract bool request(string someTrouble);
    }
}
