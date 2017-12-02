using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._14_Command__命令模式_.Practical2
{
    [Serializable]
    public class InsertCommand : Command {

        public InsertCommand(string name,string args):base(name, args) { }

        public override void execute() {
            this.configOperator.insert(this.args);
        }

        public override void execute(string args) {
            this.args = args;
            this.configOperator.insert(this.args);
        }
    }
}
