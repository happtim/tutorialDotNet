using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Equals
{
    [TestClass]
    public class ObjectEqualsTest {

        List<People> list = new List<People> {
            new People { Name = "Tim" },
            new People { Name = "Tom" },
            new People { Name = "Sam" },
        };

        [TestMethod]
        public void Test() {

            //如果有IEquatable接口, 集合内就调用IEquatable接口,否则调用Object.Equatable
            int index = list.IndexOf(new People() { Name = "Sam" });
            Assert.AreEqual(index, 2);

        }

    }
}
