using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guide._09_Generics
{
    //泛型 delegate
    public delegate void Del<T>(T item);

    [TestClass]
    public class _09_Delegate {
        //方法需要指定类型
        public static void Notify(int i) { }

        [TestMethod]
        public void Test() {
            Del<int> m1 = new Del<int>(Notify);
        }


        // 方法需要 指定类型
        private static void DoWork(float[] items) { }

        [TestMethod]
        public void Test2() {
            Stack<float> s = new Stack<float>();
            Stack<float>.StackDelegate d = DoWork;
        }
    }

    /// <summary>
    /// 代理在类中
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Stack<T> {
        T[] items;
        int index;

        public delegate void StackDelegate(T[] items);
    }

}
