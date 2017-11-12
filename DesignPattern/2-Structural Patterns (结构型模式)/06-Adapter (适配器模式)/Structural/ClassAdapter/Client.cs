using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern.Adapter.Structural.ClassAdapter
{
    /// <summary>
    /// 使用类继承的方式实现
    /// </summary>
    [TestClass]
    public class Client {

        [TestMethod]
        public void function() {

            ITarget t = new Adapter();
            t.targetMethod1();
        }
    }
}
