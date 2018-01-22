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


    }
}
