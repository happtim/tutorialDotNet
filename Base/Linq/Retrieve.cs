using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Linq
{
    [TestClass]
    public class Retrieve
    {
        string[] array = new string[]{ "asp.net","csharp","xhtml","css","javascript",
            "wcf","wpf","silverlight","linq","wf",
            "sqlserver","asp.net ajax","ssis","ssas","ssrs"};

        [TestMethod]
        //DefaultIfEmpty 如果集合有内容返回,如果没有返回默认值
        //DefaultIfEmpty(value) 同上只是返回value为默认值
        //Empty 返回空的 IEnumerable<T>
        public void testEmpty()
        {
            string[] s = new string[] { "1", "2" };

            string s2 = s.DefaultIfEmpty().Aggregate((a, b) => a + b);
            Assert.AreEqual(s2, "12");
        }

        [TestMethod]
        //FirstOrDefault 获取符合条件的第一个,如果没有返回默认值
        //First          获取符合条件的第一个,如果没有抛出异常
        //LastOrDefault
        //Last
        public void testFirst()
        {
            //以s开头
            string s = array.FirstOrDefault(a => a.StartsWith("s"));
            Assert.AreEqual("silverlight", s);

            //First 如果没有匹配抛出异常
            //s = array.First(a => a.StartsWith("xxx"));
        }

        [TestMethod]
        //ElementAtOrDefault
        //ElementAt
        public void testElement()
        {
            string s = array.ElementAtOrDefault(3);
            Assert.AreEqual("xhtml", s);
        }

        [TestMethod]
        //Single 返回一个元素,如果没有一个元素如多个元素就异常
        //SingleOrDefault  返回一个元素,如果没有该元素就返回默认值
        public void testSingle()
        {
            string single = array.Single(s => s.Length >= 12);
            Assert.AreEqual("asp.net ajax", single);

            string single2 = array.SingleOrDefault(s => s.Length > 13);
            Assert.AreEqual(null, single2);

        }
    }
}
