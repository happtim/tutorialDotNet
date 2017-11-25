using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._17_Mediator__中介者模式_.Structural
{
    public abstract class Mediator {

        protected List<Colleague> colleagues = new List<Colleague>();

        public void RegisterColleagues(Colleague colleague) {
            colleagues.Add(colleague);
        }
        public abstract void ColleagueChanged();

    }
}
