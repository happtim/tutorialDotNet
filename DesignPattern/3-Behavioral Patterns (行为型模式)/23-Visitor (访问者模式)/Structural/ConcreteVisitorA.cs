﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._23_Visitor__访问者模式_.Structural
{
    public class ConcreteVisitorA : Visitor
    {
        public override void visit(ConcreteElementA elementA) {
            Console.WriteLine("ConcreteVisitorA visitor elementA");
        }

        public override void visit(ConcreteElementB elementB) {
            Console.WriteLine("ConcreteVisitorA visitor elementB");
        }
    }
}
