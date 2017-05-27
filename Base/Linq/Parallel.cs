using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Base.Linq
{
    [TestClass]
    public class Parallel
    {

        static int SumDefault(int[] array)
        {
            /*
             *
             * Sum all numbers in the array.
             *
             * */
            return array.Sum();
        }

        static int SumAsParallel(int[] array)
        {
            /*
             *
             * Enable parallelization and then sum.
             *
             * */
            return array.AsParallel().Sum();
        }


        [TestMethod]
        //运用cpu的多核特性
        public void testAsParallel()
        {
            int[] array = Enumerable.Range(0, short.MaxValue).ToArray();

            const int m = 10000;
            var s1 = Stopwatch.StartNew();
            for (int i = 0; i < m; i++)
            {
                SumDefault(array);
            }
            s1.Stop();
            var s2 = Stopwatch.StartNew();
            for (int i = 0; i < m; i++)
            {
                SumAsParallel(array);
            }
            s2.Stop();
            Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds * 1000000) /
                m).ToString("0.00 ns"));
            Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds * 1000000) /
                m).ToString("0.00 ns"));
            Console.Read();

        }
    }
}
