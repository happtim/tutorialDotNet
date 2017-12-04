using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._13_Chain_of_Responsibility__职责链模式_.Practical
{
    public class LimitSupport : Support {

        private int limit;

        public LimitSupport(string name,int limit) : base(name) {
            this.limit = limit;
        }

        protected override bool resolve(Trouble trouble) {
            if(trouble.Number < limit) {
                return true;
            } else {
                return false;
            }
        }
    }
}
