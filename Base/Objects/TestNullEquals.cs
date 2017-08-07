using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Objects
{
    [TestClass]
    public class TestNullEquals {

        [TestMethod]
        public void testNull() {

            object a = null;
            object b = null;

            Assert.AreEqual(true, a == b);
        }
    }
}
