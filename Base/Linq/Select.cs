using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Linq
{
    [TestClass]
    public class Select
    {
        [TestMethod]
        //对每个元素做个运算,这个方法比较优雅
        public void testSelect()
        {
            string[] array = { "cat", "dog", "mouse" };

            var result = array.Select(element => element.ToUpper());

            foreach( string value in result)
            {
                Console.WriteLine(value);
            }
        }
    }
}
