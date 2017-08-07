using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Linq
{
    [TestClass]
    public class All {

        [TestMethod]
        public void testAll() {

            List<int> list = new List<int>();

            bool result = list.All(i => i > 0);
            Assert.AreEqual(true,result);

        }
    }
}
