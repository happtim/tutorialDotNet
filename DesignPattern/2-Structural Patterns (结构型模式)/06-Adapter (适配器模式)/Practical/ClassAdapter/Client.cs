using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._06_Adapter__适配器模式_.Practical.ClassAdapter
{

    /// <summary>
    /// 成功将 printWithAStar printWithParen 适配为 printWeak printStrong
    /// </summary>
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {

            Print p = new PrintBanner("Hello");
            p.printWeak();
            p.printStrong();
        }
    }
}
