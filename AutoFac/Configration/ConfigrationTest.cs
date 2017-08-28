using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Autofac;
using Microsoft.Extensions.Configuration;
using Autofac.Configuration;

using AutofacIOC.Comm;

namespace AutofacIOC.Configration
{
    [TestClass]
    public class ConfigrationTest
    {

        [TestMethod]
        public void Test() {
            // Add the configuration to the ConfigurationBuilder.
            var config = new ConfigurationBuilder();
            // config.AddJsonFile comes from Microsoft.Extensions.Configuration.Json
            // config.AddXmlFile comes from Microsoft.Extensions.Configuration.Xml
            config.AddXmlFile("autofac_config.xml");

            // Register the ConfigurationModule with Autofac.
            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);

            var container = builder.Build();

            using(var scope = container.BeginLifetimeScope()) {
                var reader = container.Resolve<IConfigReader>();
//                  var reader = container.ResolveNamed<IConfigReader>("0");
//                var reader = container.ResolveKeyed<IConfigReader>("key1");

                string something = reader.read();
                Assert.AreEqual("May 5, 2014", something);
            }



        }
    }
}
