using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._09_Decorator__装饰模式_.Practical
{
    public abstract class Border : Display {

        protected Display dispaly;

        protected Border( Display display) {
            this.dispaly = display;
        }
    }
}
