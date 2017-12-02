using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._14_Command__命令模式_.Practical2
{
    [Serializable]
    public abstract class Command {
        protected string name;
        protected string args;
        protected ConfigOperator configOperator;

        public Command(string name,string args) {
            this.name = name;
            this.args = args;
        }

        public void SetConfigOperator(ConfigOperator configOperator) {
            this.configOperator = configOperator;
        }

        public abstract void execute();
        public abstract void execute(string args);
    }
}
