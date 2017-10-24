using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern.Behavior.Template
{
    [TestClass]
    public class Test {

        [TestMethod]
        public void TestTempalte() {

            Account acc = new CurrentAccount();
            acc.Handle("user", "123456");
        }
    }
}
