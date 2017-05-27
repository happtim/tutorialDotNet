using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Linq
{
    [TestClass]
    public class Convert
    {
        [TestMethod]
        //转换为数组
        public void testToArray()
        {
            int[] array = { 5, 4, 1, 2, 3 };

            var query = from element in array
                        orderby element
                        select element;
            int[] array2 = query.ToArray();

            foreach( var i in array2)
            {
                Console.WriteLine(i);
            }
        }

        [TestMethod]
        public void testTODictionary()
        {
            int[] array = { 1, 3, 5, 7 };

            Dictionary<int,bool> dictionary  =  array.ToDictionary(i => i, i => true);

            foreach( KeyValuePair<int,bool> pair in dictionary)
            {
                Console.WriteLine(pair);
            }
        }

    }
}
