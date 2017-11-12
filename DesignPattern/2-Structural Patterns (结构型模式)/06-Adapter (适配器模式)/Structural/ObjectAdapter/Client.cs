using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern.Adapter.Structural.ObjectAdapter
{

    /// <summary>
    /// 使用委托的方式实现,将某个方法的实际处理交给其他实例实现
    /// </summary>
    [TestClass]
    public class Client {

        [TestMethod]
        public void function() {

            Target t = new Adapter();
            t.targetMethod1();

        }

    }
}
