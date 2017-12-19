using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._01_Abstract_Factory__抽象工厂模式_.Structural
{
    public class Client {
        private AbstractProductA abstractProductA;
        private AbstractProductB abstractProductB;

        public Client(AbstractFactory abstractFactory ) {
            abstractProductA = abstractFactory.CreateProductA();
            abstractProductB = abstractFactory.CreateProductB();
        }

        public void Run() {
            abstractProductB.Interact(abstractProductA);
        }

    }
}
