using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpGuide._10_StatementsExpressionsOperators._03_Operators
{
    /// <summary>
    /// c# 可以声明一个转化,从其他类转化成这个类
    /// </summary>
    [TestClass]
    public class Conversion {

        struct Digit {

            byte value;

            public Digit(byte value) {
                if(value > 9) {
                    throw new System.ArgumentException();
                }
                this.value = value;
            }
            /*
            public static implicit 目标类型(被转化类型 变量参数) {
               return 目标类型结果;
            }

            public static explicit 目标类型(被转化类型 变量参数) {
               return 目标类型结果;
            }
             */

            /// <summary>
            /// byte --> Digit 
            /// explicit 显示转换
            /// implicit 隐式转换
            /// </summary>
            /// <param name="b"></param>
            public static implicit  operator Digit(byte b) {
                Digit d = new Digit(b);
                System.Console.WriteLine("Conversion occurred.");
                return d;
            }

            public static explicit operator byte(Digit d) {
                System.Console.WriteLine("conversion occurred");
                return d.value;  // implicit conversion
            }

        }

        [TestMethod]
        public void Test() {
            try
            {
                byte b = 3;
                Digit d = (Digit)b;  // 显示转换
                Digit dd = b;        // 隐式转换

                b = (byte)d;         // 显示转换
                //b = d;             // 隐式转换
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}
