using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Linq
{
    [TestClass]
    public class SkipTake
    {
        [TestMethod]
        //Skip 跳过几个元素
        public void testSkip()
        {
            int[] array = { 1, 3, 5, 7, 9, 11 };
            Assert.AreEqual(5, array.Skip(2).ElementAt(0)); //5,7,9,11
        }

        [TestMethod]
        //SkipWhile 跳过符合需求的元素,直到第一个满足为止
        public void testSkipWhile()
        {
            int[] array = { 1, 3, 5, 10, 20 ,7,9};
            var result = array.SkipWhile(element => element < 10);
            //10,20,7 ,9
            foreach(var i in result)
            {
                Console.WriteLine(i);
            }
        }

        [TestMethod]
        //取出前n个值
        public void testTake()
        {
            int[] array = { 1, 3, 5, 10, 20 };
            var result = array.Take(2);//1,3
            foreach(var i in result)
            {
                Console.WriteLine(i);
            }
        }

        [TestMethod]
        //取出符合条件的值,直到不满足为止
        public void testTakeWhile()
        {
            int[] array = { 2, 4, 5, 10, 20 };
            var result = array.TakeWhile(i => i % 2 == 0 );
            foreach(var i in result)
            {
                Console.WriteLine(i);
                //2,4
            }
        }
    }
}
