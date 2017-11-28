using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._14_Command__命令模式_.Structural
{
    public class ConcreteCommand : Command {

        private Receiver receiver;

        public ConcreteCommand(Receiver receiver) {
            this.receiver = receiver;
        }

        public void execute() {
            receiver.action();
        }
    }
}
