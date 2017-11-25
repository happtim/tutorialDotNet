using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._17_Mediator__中介者模式_.Structural
{
    public abstract class Colleague {
        private Mediator mediator;

        public void SetMediator(Mediator mediator) {
            this.mediator = mediator;
        }

        public abstract void ControlColleague();

        public void NotifyMediator() {
            mediator.ColleagueChanged();
        }
    }
}
