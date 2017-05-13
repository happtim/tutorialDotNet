using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Enums
{
    //枚举本身可以有修饰符,但枚举的成员始终是公共的,不能有访问修饰符
    //枚举本身的修饰符仅能使用public和internal
    public enum WeekEnum
    {
        //显式设置枚举的成员常量值,默认是从0开始,逐个递增的
        Sunday = 1,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    [TestClass()]
    public class TestEnum {

        [TestMethod()]
        public void test() {

            //GetNames 获取枚举类型的名
            Assert.AreEqual("Sunday Monday Tuesday Wednesday Thursday Friday Saturday",
                String.Join(" ", Enum.GetNames(typeof(WeekEnum)))
            );

            //获取指定值的名
            Assert.AreEqual("Sunday",
                Enum.GetName(typeof(WeekEnum), 1)
            );


        }
    }
}
