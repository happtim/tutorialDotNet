using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Collections
{
    [TestClass()]
    public class CollectionObject
    {

        //数组形式
        [TestMethod()]
        public void testArrayList() {
            ArrayList array = new ArrayList();
            array.Add(1);

            Assert.AreEqual(
                1,
                array[0]
            );


            array.Add(2);
            Assert.AreEqual(
                1,
                array.IndexOf(2)
            );

            //末尾插入
            array.Insert(2, 3);
            Assert.AreEqual(
                3,
                array[2]
            );
        }
    }
}
