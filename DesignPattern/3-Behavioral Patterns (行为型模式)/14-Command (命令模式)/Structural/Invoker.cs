using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._14_Command__命令模式_.Structural
{
    public class Invoker {
        private Command command;
        //构造注入
        public Invoker(Command command) {
            this.command = command;
        }

        //设值注入
        public void SetCommand(Command command) {
            this.command = command;
        }

        public void call() {
            command.execute();
        }
    }
}
