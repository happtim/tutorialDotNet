using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._17_Mediator__中介者模式_.Structural
{
    public class ConcreteMediator : Mediator {

        /// <summary>
        /// 收集各个同事发来的变化,统一逻辑处理
        /// </summary>
        public override void ColleagueChanged() {
            //....
            if(colleagues.Count > 0) {
                colleagues[0].ControlColleague();
            }
        }

      

    }
}
