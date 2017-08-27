using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Autofac;
using AutofacIOC.Comm;
using System.IO;

namespace AutofacIOC.Registration
{
    /// <summary>
    /// 有些时候希望预先生成一些对象,然后再获取出来
    /// </summary>
    [TestClass]
    public class InstanceTest {

        [TestMethod]
        public void Test() {
            var builder = new ContainerBuilder();

            //ExternallyOwned 自己控制生命周期
            var output = new StringWriter();
            builder.RegisterInstance(output).As<TextWriter>();
            var container = builder.Build();


            using(var scope = container.BeginLifetimeScope()) {
                var writer = scope.Resolve<TextWriter>();
                writer.Write("123");
            }

            output.Write("456");
            Assert.AreEqual("123456", output.ToString() ); 
            //file.Write(bytes,0,bytes.Length);

        }
    }
}
