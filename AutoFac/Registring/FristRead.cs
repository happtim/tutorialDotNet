using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Autofac;
using AutofacIOC.Comm;

namespace AutofacIOC.Registration
{
    /// <summary>
    /// containerBuilder 可以注册一个组件
    /// 组件可以通过反射,实例,lambda创建出来
    /// </summary>
    [TestClass]
    public class FristRead {

        [TestMethod]
        public void Test() {
            // Create the builder with which components/services are registered.
            var builder = new ContainerBuilder();

            // Register types that expose interfaces...
            builder.RegisterType<ConsoleLogger>().As<ILogger>();

            // Register instances of objects you create...
            var output = new StringWriter();
            builder.RegisterInstance(output).As<TextWriter>();

            // Register expressions that execute to create objects...
            builder.Register(c => new ConfigReader("Setting1")).As<IConfigReader>();

            // Build the container to finalize registrations
            // and prepare for object resolution.
            var container = builder.Build();

            // Now you can resolve services using Autofac. For example,
            // this line will execute the lambda expression registered
            // to the IConfigReader service.
            using (var scope = container.BeginLifetimeScope()) {

                var reader = container.Resolve<IConfigReader>();
                string something = reader.read();
                Assert.AreEqual("May 5, 2014", something);
                
            }

        }

    }
}
