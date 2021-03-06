﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._14_Command__命令模式_.Practical
{
    /// <summary>
    /// 命令接受者
    /// </summary>
    public class DrawConsole : Drawable {

        private MacroCommand history;

        public DrawConsole(MacroCommand history) {
            this.history = history;
        }

        public void paint() {
            history.execute();
        }

        public void draw() {
            Console.WriteLine("DrawSomeThing");
        }
    }
}
