using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._14_Command__命令模式_.Practical
{
    /// <summary>
    /// 命令栈
    /// </summary>
    public class MacroCommand : Command {

        private Stack<Command> commands = new Stack<Command>();

        public void execute() {
            foreach(var command in commands) {
                command.execute();
            }
        }

        public void append(Command command) {
            commands.Push(command);
        }

        public void undo() {
            if(commands.Count > 0) {
                commands.Pop();
            }
        }

        public void clear() {
            commands.Clear();
        }
    }
}
