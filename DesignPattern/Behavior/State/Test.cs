using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern.Behavior.State
{
    [TestClass()]
    public class Test
    {
        [TestMethod()]
        public void test() {

            Context context = new Context();

            context.Week = WeekEnum.Sunday;
            context.changeState();
            Assert.AreEqual(context.request(), "Sunday");

            context.Week = WeekEnum.Monday;
            context.changeState();
            Assert.AreEqual(context.request(), "Monday");

        }

    }
}
/*
Assert
    Assert.Inconclusive()    表示一个未验证的测试；
    Assert.AreEqual()         测试指定的值是否相等，如果相等，则测试通过；
    AreSame()            用于验证指定的两个对象变量是指向相同的对象，否则认为是错误
    AreNotSame()        用于验证指定的两个对象变量是指向不同的对象，否则认为是错误
    Assert.IsTrue()              测试指定的条件是否为True，如果为True，则测试通过；
    Assert.IsFalse()             测试指定的条件是否为False，如果为False，则测试通过；
    Assert.IsNull()               测试指定的对象是否为空引用，如果为空，则测试通过；
    Assert.IsNotNull()          测试指定的对象是否为非空，如果不为空，则测试通过；
    
CollectionAssert
    用于验证对象集合是否满足条件

StringAssert
    用于比较字符串。
    StringAssert.Contains
    StringAssert.Matches
    StringAssert.tartWith
*/
