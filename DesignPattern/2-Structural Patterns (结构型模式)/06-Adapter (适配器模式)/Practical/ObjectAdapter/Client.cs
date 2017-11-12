using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._06_Adapter__适配器模式_.Practical.ObjectAdapter
{
    [TestClass]
    public class Client
    {
        [TestMethod]
        public void Test() {

            Power12V powner = new Adapter();
            Assert.AreEqual( powner.GetPower(), 12);
        }
    }
}
