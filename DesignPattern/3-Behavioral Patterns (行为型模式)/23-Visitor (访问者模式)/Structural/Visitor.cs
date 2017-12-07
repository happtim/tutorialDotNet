using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._23_Visitor__访问者模式_.Structural
{
    public abstract class Visitor {
        public abstract void visit(ConcreteElementA elementA);
        public abstract void visit(ConcreteElementB elementB);
    }
}
