using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Linq
{
    [TestClass]
    public class Computation
    {
        string[] array = new string[]{ "asp.net","csharp","xhtml","css","javascript",
            "wcf","wpf","silverlight","linq","wf",
            "sqlserver","asp.net ajax","ssis","ssas","ssrs"};

        [TestMethod]
        //聚合函数 , 两两聚合
        public void testAggregate()
        {

            int[] array = { 1, 2, 3, 4, 5 };
            int result = array.Aggregate((a, b) => b + a);
            Assert.AreEqual(15, result);

            string sentence = "the quick brown fox jumps over the lazy dog";
            string[] words = sentence.Split(' ');
            string reversed = words.Aggregate((workingSentence, next) => next + " " + workingSentence);
            Assert.AreEqual("dog lazy the over jumps fox brown quick the", reversed);
        }

        [TestMethod]
        //Any 判断满足集合中是否有满足条件
        //All 判断集合所有都满足条件
        public void testAnyAndAll()
        {
          

            bool b = array.Any(a => a.Length > 10);
            Assert.AreEqual(true, b);

            b = array.All(a => a.Length > 10);
            Assert.AreEqual(false, b);
        }

        [TestMethod]
        ///去平均数
        public void testAverage()
        {
            double[] array = { 1, 2, 3, 5, 0 };
            double average = array.Average();

            Assert.AreEqual(2.2, average);
        }

        [TestMethod]
        //Count 返回元素个数
        //LongCount
        public void testCount()
        {
            Assert.AreEqual(array.Length, array.Count());
        }

        [TestMethod]
        //求和
        public void testSum()
        {
            //字符长度总和
            int sum = (from i in array select i.Length).Sum();
        }

        [TestMethod]
        public void testSequenceEqual()
        {
            string[] array1 = { "dot", "net", "perls" };
            string[] array2 = { "a", "different", "array" };
            string[] array3 = { "dot", "net", "perls" };
            string[] array4 = { "DOT", "NET", "PERLS" };

            bool a = array1.SequenceEqual(array2);
            bool b = array1.SequenceEqual(array3);
            bool c = array1.SequenceEqual(array4, StringComparer.OrdinalIgnoreCase);

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);

        }

    }
}
