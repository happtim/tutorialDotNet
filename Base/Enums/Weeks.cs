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

            WeekEnum sunday = WeekEnum.Sunday;
            //枚举类型转换其他类型

            //枚举类型 -> 字符串整数
            Assert.AreEqual(
                "1",
                Enum.Format(typeof(WeekEnum),WeekEnum.Sunday,"d")
            );

            Assert.AreEqual(
                "1",
                sunday.ToString("D")
            );
            //error 格式字符串只能是“G”、“g”、“X”、“x”、“F”、“f”、“D”或“d”
            //Assert.AreEqual("01",sunday.ToString("D2"));

            //枚举类型 --> 整数
            Assert.AreEqual(
                1,
                (int)WeekEnum.Sunday
            );

            //枚举类型 -> 字符串
            Assert.AreEqual(
                "Sunday",
                Enum.GetName(typeof(WeekEnum), sunday)
            );

            Assert.AreEqual(
                "Sunday",
                sunday.ToString()
            );

            //其他类型转枚举类型

            //字符串 -> 枚举类型
            Assert.AreEqual(
                WeekEnum.Sunday,
                Enum.Parse(typeof(WeekEnum),"Sunday")
            );

            //字符串 -> 枚举类型
            Assert.AreEqual(
                WeekEnum.Sunday,
                Enum.Parse(typeof(WeekEnum),"1")
            );


            //获取所有值

            //GetNames 获取枚举类型的名
            Assert.AreEqual(
                "Sunday Monday Tuesday Wednesday Thursday Friday Saturday",
                string.Join(" ",
                    Enum.GetNames(typeof(WeekEnum))
                )
            );

            //获取所有的值
            Assert.AreEqual(
                WeekEnum.Sunday,
                Enum.GetValues(typeof(WeekEnum)).GetValue(0)
            );


        }
    }
}
