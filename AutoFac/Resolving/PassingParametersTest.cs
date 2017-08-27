using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Autofac;
using AutofacIOC.Comm;
using Autofac.Core;

namespace AutofacIOC.Resolving
{
    /// <summary>
    /// 通过传递参数初始化
    /// 有3种方式
    /// NamedParameter 
    /// TypedParameter 
    /// ResolvedParameter 
    /// </summary>
    [TestClass]
    public class PassingParametersTest {

        [TestMethod]
        public void Test() {

            var builder = new ContainerBuilder();
            builder.Register(c => new ConfigReader("sectionName")).As<IConfigReader>();

            // Using a NAMED parameter:
            builder.RegisterType<ConfigReader>()
                   .As<IConfigReader>()
                   .WithParameter("configSectionName", "sectionName");

            // Using a TYPED parameter:
            builder.RegisterType<ConfigReader>()
                   .As<IConfigReader>()
                   .WithParameter(new TypedParameter(typeof(string), "sectionName"));

            // Using a RESOLVED parameter:
            builder.RegisterType<ConfigReader>()
                   .As<IConfigReader>()
                   .WithParameter(
                     new ResolvedParameter(
                       (pi, ctx) => pi.ParameterType == typeof(string) && pi.Name == "configSectionName",
                       (pi, ctx) => "sectionName"));

            var container = builder.Build();
        }
    }
}
