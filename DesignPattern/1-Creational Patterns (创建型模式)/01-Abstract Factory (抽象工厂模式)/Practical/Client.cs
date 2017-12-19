using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._01_Abstract_Factory__抽象工厂模式_.Practical
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {
            KFCFactory factory = new CheapPackageFactory();
            KFCDrink drink = factory.CreateDrink();
            drink.Dispaly();

            KFCFood food = factory.CreateFood();
            food.Display();
        }
    }
}
