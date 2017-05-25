using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Linq
{
    [TestClass]
    public class TestLinq
    {
        string [] array = new string[]{ "asp.net","csharp","xhtml","css","javascript",
            "wcf","wpf","silverlight","linq","wf",
            "sqlserver","asp.net ajax","ssis","ssas","ssrs"};

        [TestMethod]
        //FirstOrDefault
        //First
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
        //DefaultIfEmpty 如果集合有内容返回,如果没有返回默认值
        //DefaultIfEmpty(value) 同上只是返回value为默认值
        //Empty 返回空的 IEnumerable<T>
        public void testDefault()
        {
            string[] s = new string[] { "1", "2" };

            string s2 = s.DefaultIfEmpty().Aggregate((a, b) => a + b);
            Assert.AreEqual(s2, "12");
        }

        [TestMethod]
        //Single 返回一个元素,如果没有一个元素就异常
        //SingleOrDefault  返回一个元素,如果没有该元素就返回默认值
        public void testSingle()
        {
            string single = array.Single(s => s.Length >= 12);
            Assert.AreEqual("asp.net ajax", single);

            string single2 = array.SingleOrDefault(s => s.Length > 13);
            Assert.AreEqual(null, single2);

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
        //Contains
        public void testContains()
        {
            bool found = array.Contains("css");
            Assert.AreEqual(true, found);
        }


        [TestMethod]
        //Any 判断满足集合中是否有满足条件
        //All 判断集合所有都满足条件
        public void testAny()
        {
            bool b = array.Any(a => a.Length > 10);
            Assert.AreEqual(true, b);

            b = array.All(a => a.Length > 10);
            Assert.AreEqual(false, b);
        }

        [TestMethod]
        //Count 返回元素个数
        //LongCount
        public void testCount()
        {
            Assert.AreEqual(array.Length, array.Count());
        }

        [TestMethod]
        //Sum
        //Mix
        //Min
        //Average
        public void testSum() {

            //字符长度总和
            int sum = (from i in array select i.Length).Sum();
            int min = array.Min(a => a.Length);
            Assert.AreEqual(2, min);

            int max = array.Max(a => a.Length);
            Assert.AreEqual(12, max);

            double averageLength = array.Average(a => a.Length);
            Console.WriteLine(averageLength);
        }


        [TestMethod]
        //聚合函数
        public void testAggregate() {

            int sum = (from i in array select i.Length).Aggregate((x, y) => x + y);
            Assert.AreEqual(87, sum);

            string sentence = "the quick brown fox jumps over the lazy dog";
            string[] words = sentence.Split(' ');
            string reversed = words.Aggregate((workingSentence, next) => next + " " + workingSentence);
            Assert.AreEqual("dog lazy the over jumps fox brown quick the", reversed);

        }

        [TestMethod]
        //Cast 将集合IEnumerable转为其他类型集合IEnumerable<T>
        public void testCast()
        {
            System.Collections.ArrayList fruits = new System.Collections.ArrayList();
            fruits.Add("mango");
            fruits.Add("apple");
            fruits.Add("lemon");

            IEnumerable<string> query =
                fruits.Cast<string>().OrderBy(fruit => fruit).Select(fruit => fruit);

            // The following code, without the cast, doesn't compile.
            //IEnumerable<string> query1 =
            //    fruits.OrderBy(fruit => fruit).Select(fruit => fruit);

            foreach (string fruit in query)
            {
                Console.WriteLine(fruit);
            }

            // This code produces the following output: 
            //
            // apple 
            // lemon
            // mango
        }

        [TestMethod]
        public void testConcat()
        {
            string[] s1 = new string[] { "1" };
            string[] s2 = new string[] { "2" };
            var s3 = s1.Concat(s2);
            foreach(var s in s3)
            {
                Console.WriteLine(s);
            }
        }

        [TestMethod]
        public void testDistinct()
        {
            List<int> ages = new List<int> { 21, 46, 46, 55, 17, 21, 55, 55 };

            IEnumerable<int> distinctAges = ages.Distinct();


            foreach (int age in distinctAges)
            {
                Console.WriteLine(age);
            }

            /*
             21
             46
             55
             17
            */

        }


    }
}
