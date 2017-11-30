using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._14_Command__命令模式_.Practical
{
    [TestClass]
    public class Client {

        private MacroCommand history;
        private DrawConsole draw;

        [TestMethod]
        public void Test() {
            history = new MacroCommand();
            draw = new DrawConsole(history);

            mouseDragged();
            mouseDragged();
            mouseDragged();

            Console.WriteLine();

            draw.paint();

        }

        public void mouseDragged() {
            Command command = new DrawCommand(draw);
            history.append(command);
            command.execute();
        }
    }
}
