using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._09_Decorator__装饰模式_.Structural
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void test() {

            Component c = new ConcreteComponent();
            Decorator dc = new ConcreteDecorator(c);
            dc.Method1();

            /*
            new StreamReader(
                new BufferedStream(
                    new FileStream("C:\a.txt", FileMode.Create)
                )
             );
            */


        }
    }
}
