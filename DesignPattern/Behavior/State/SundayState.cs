using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Behavior.State
{
    public class SundayState : State
    {
        public override string handle()
        {
            return "Sunday";
        }
    }
}
