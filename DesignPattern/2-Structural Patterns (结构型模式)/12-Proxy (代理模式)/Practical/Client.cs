using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._12_Proxy__代理模式_.Practical
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {
            //Tim 的打印机
            Printable p = new PrinterProxy("Tim");
            //Tom 打印机
            p.SetPrinterName("Tom");
            p.Print("Hello World!");

        }
    }
}
