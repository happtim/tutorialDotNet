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
    public class _02_ConstructorInfo {
        public _02_ConstructorInfo() { }
        static _02_ConstructorInfo() { }
        public _02_ConstructorInfo(int i) { }


        //constructor
        //Void.ctor()
        //Void.ctor(Int32)
        [TestMethod]
        public void Test() {
            Type t = typeof(string);
            //Construct
            ConstructorInfo[] cis = t.GetConstructors(BindingFlags.Instance | BindingFlags.Public );

            foreach(MemberInfo mi in cis) {
                Console.WriteLine(mi);
            }
        }
    }
}
