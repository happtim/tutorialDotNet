using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Autofac;
using AutofacIOC.Comm;

namespace AutofacIOC.Registration
{
    [TestClass]
    public class ReflectionTest {

        [TestMethod]
        public void Test() {

            //注册类型
            var builder = new ContainerBuilder();
            builder.RegisterType<MyComponent>();
            builder.RegisterType<ConsoleLogger>().As<ILogger>();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                //构建对象时使用最多匹配参数去创建
                var component = container.Resolve<MyComponent>();
            }

        }
    }
}
