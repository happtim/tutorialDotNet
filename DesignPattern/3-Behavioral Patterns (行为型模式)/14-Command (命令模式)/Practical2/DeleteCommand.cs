using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._14_Command__命令模式_.Practical2
{
    [Serializable]
    public class DeleteCommand : Command {

        public DeleteCommand(string name, string args):base(name, args) { }

        public override void execute() {
            this.configOperator.delete(this.args);
        }

        public override void execute(string args) {
            this.args = args;
            this.configOperator.delete(this.args);
        }
    }
}
