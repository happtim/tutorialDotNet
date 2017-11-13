using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._09_Decorator__装饰模式_.Practical
{
    
    [TestClass]
    public class Client {

        [TestMethod]
        public void test() {
            Display b1 = new StringDisplay("Hello World!");
            Display b2 = new SideBorder(b1, '#');
            Display b3 = new FullBorder(b2);
            b1.show();
            b2.show();
            b3.show();
        }
            
    }
}
