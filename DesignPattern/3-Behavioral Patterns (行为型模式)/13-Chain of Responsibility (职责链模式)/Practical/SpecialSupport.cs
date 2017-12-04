using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._13_Chain_of_Responsibility__职责链模式_.Practical
{
    public class SpecialSupport : Support {
        private int number;
        public SpecialSupport(string name,int number) : base(name) {
            this.number = number;
        }

        protected override bool resolve(Trouble trouble) {
            if(trouble.Number == number) {
                return true;
            } else {
                return false;
            }
        }
    }
}
