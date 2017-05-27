using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Linq
{
    [TestClass]
    public class MaxMin
    {
        string[] array = new string[]{ "asp.net","csharp","xhtml","css","javascript",
            "wcf","wpf","silverlight","linq","wf",
            "sqlserver","asp.net ajax","ssis","ssas","ssrs"};

        [TestMethod]
        public void testMaxAndMin()
        {
            int min = array.Min(a => a.Length);
            Assert.AreEqual(2, min);

            int max = array.Max(a => a.Length);
            Assert.AreEqual(12, max);
        }
    }
}
