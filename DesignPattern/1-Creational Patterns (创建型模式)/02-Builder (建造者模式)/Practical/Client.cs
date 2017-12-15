using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._02_Builder__建造者模式_.Practical
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {
            TextBuilder textBuilder = new TextBuilder();
            Director director = new Director(textBuilder);
            director.construct();
            Console.WriteLine(textBuilder.getResult());
        }
    }
}
