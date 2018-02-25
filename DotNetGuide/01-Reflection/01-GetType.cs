using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetGuide._01_ViewTypes
{
    /// <summary>
    /// Type是Reflection的中心.拿到他就能拿到其他的信息
    /// </summary>
    [TestClass]
    public class GetType {

        /// <summary>
        /// 使用typeof 关键字获取Type
        /// </summary>
        [TestMethod]
        public void Way1() {

            Type type = typeof(GetType);
            Console.WriteLine( type.FullName );
        }

        /// <summary>
        /// 根据对象获取Type
        /// </summary>
        [TestMethod]
        public void Way2() {
            string s = "";
            Type type = s.GetType();
            Console.WriteLine(type.FullName);
        }

        /// <summary>
        /// 使用Assembly 获取Types
        /// </summary>
        [TestMethod]
        public void Way3() {
            Assembly a = typeof(GetType).Assembly;
            Type [] types = a.GetTypes();
            foreach(Type t in types) {
                Console.WriteLine(t.FullName);
            }
        }

        /// <summary>
        /// 使用Module获取Types
        /// </summary>
        [TestMethod]
        public void Way4() {
            Module m = typeof(GetType).Module;
            Console.WriteLine(m.Name);

            Type [] types = m.GetTypes();
            foreach( Type t in types) {
                Console.WriteLine(t.FullName);
            }
        }


        class SomeThing :ICloneable{
            public string name;
            public string age;

            public object Clone() {
                return new SomeThing { name = this.name, age = this.age };
/*
                SomeThing other = (SomeThing) this.MemberwiseClone();
                other.name = this.name;
                other.age = this.age;
                return other;
                */
            }
        }

        [TestMethod]
        public void Test5() {

            DateTime now = DateTime.Now;

            for(int i = 0 ; i < 100000; ++i){
                Random rd = new Random(1);
                rd.Next();
            }

            Console.WriteLine( DateTime.Now - now);


        }
      
    }
}
