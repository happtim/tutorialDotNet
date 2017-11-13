using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._09_Decorator__装饰模式_.Structural
{
    public abstract class Decorator : Component {

        protected Component component = null;

        public Decorator(Component component) {
            this.component = component;
        }
    }
}
