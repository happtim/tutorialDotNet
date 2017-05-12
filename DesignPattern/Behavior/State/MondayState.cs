using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Behavior.State
{
    public class MondayState : State
    {
        public override string handle()
        {
            return "Monday";
        }
    }
}
