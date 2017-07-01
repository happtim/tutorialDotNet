using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Log4Net.Com;

//log4net 配置文件 默认使用Log4net.exe.config 配置文件
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Log4Net.AppConfig
{
    [TestClass]
    public class AppConfigTest
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [TestMethod]
        public void Test() {
            log.Info("Entering application.");
            Bar bar = new Bar();
            bar.DoIt();
            log.Info("Exiting application.");
        }
    }
}
