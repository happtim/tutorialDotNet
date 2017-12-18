using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._03_Factory_Method__工厂方法_.Structural
{
    public class ConcreteCreator : Creator
    {
        public override Product factoryMethod() {
            return new ConcreteProduct();
        }
    }
}
