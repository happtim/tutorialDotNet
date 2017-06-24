using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using log4net;
using log4net.Config;

using Log4Net.Com;

namespace Log4Net.XmlConfig
{
    [TestClass]
    public class XmlConfigTest
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(XmlConfigTest));

        [TestMethod]
        public void Test() {

            //超过Debug级别的都能记录
            XmlConfigurator.Configure(new System.IO.FileInfo("../../XmlConfig/config.xml"));

            log.Info("Entering application.");
            Bar bar = new Bar();
            bar.DoIt();
            log.Info("Exiting application.");

        }

    }
}
