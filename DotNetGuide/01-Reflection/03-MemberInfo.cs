using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGuide._01_Reflection
{
    [TestClass]
    public class _03_MemberInfo {

        public int Age { get; set; }

        public int age;

        [TestMethod]
        public void Test() {
            Type y = typeof(_03_MemberInfo);

            // 10
            // 4 object + 1 ctor +  1 method + 1 preperty + 2 get set + 1 field
            MemberInfo[] Memberinfoarray = y.GetMembers();
            Console.WriteLine("\nThere are {0} members in {1}.",
                Memberinfoarray.Length, y.FullName);

            //获得该声明的变量
            foreach (MemberInfo mi in Memberinfoarray) {
                Console.Write(mi);
                if (mi.MemberType == MemberTypes.Constructor)
                    Console.Write(" is Constructor");
                if(mi.MemberType == MemberTypes.Field)
                    Console.Write(" is Field");
                if(mi.MemberType == MemberTypes.Property)
                    Console.Write(" is Property");
                if(mi.MemberType == MemberTypes.Method)
                    Console.Write(" is Method");
                Console.WriteLine();

            }

            //7 Exception ctor
            MemberInfo[] Methodarray = y.GetMethods();
            Console.WriteLine("\nThere are {0} methods in {1}.",
               Methodarray.Length, y.FullName);

            //获得该声明的函数
            foreach (MemberInfo mi in Methodarray)
                Console.WriteLine(mi);

            //1 Age
            MemberInfo[] Propertiesarray = y.GetProperties();
            Console.WriteLine("\nThere are {0} properties in {1}.",
               Propertiesarray.Length, y.FullName);

            //获得该声明的属性
            foreach (MemberInfo mi in Propertiesarray)
                Console.WriteLine(mi);

            //1 age
            MemberInfo[] Fieldarray = y.GetFields();
            Console.WriteLine("\nThere are {0} fields in {1}.",
               Propertiesarray.Length, y.FullName);

            //获得该类型的成员变量
            foreach( MemberInfo mi in Fieldarray) 
                Console.WriteLine(mi);



        }


    }
}
