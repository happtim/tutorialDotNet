using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using log4net;
using log4net.Config;

using Log4Net.Com;

namespace Log4Net {

    [TestClass]
    public class BasicConfiguration
    {
        // Define a static logger variable so that it references the
        // Logger instance named "BasicConfigurator".

        private static readonly ILog log = LogManager.GetLogger(typeof(BasicConfiguration));

        /// <summary>
        /// 默认配置的输出
        /// </summary>
        [TestMethod]
        public void TestBaseConfiguration() {
            // Set up a simple configuration that logs on the console.
            BasicConfigurator.Configure();

            log.Info("Entering application.");
            Bar bar = new Bar();
            bar.DoIt();
            log.Info("Exiting application.");

        }
    }
}
