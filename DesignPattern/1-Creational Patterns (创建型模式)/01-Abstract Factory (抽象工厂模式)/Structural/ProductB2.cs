using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._01_Abstract_Factory__抽象工厂模式_.Structural
{
    public class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a) {
            Console.WriteLine(this.GetType().Name + " interact with " + a.GetType().Name);
        }
    }
}
