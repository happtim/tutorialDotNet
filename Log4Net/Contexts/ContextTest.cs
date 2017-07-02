using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

using log4net.Config;
using log4net;

using Log4Net.Com;

namespace Log4Net.Contexts
{
    [TestClass]
    public class ContextTest
    {
        //使用appConfig setting
        private static readonly ILog log = LogManager.GetLogger(typeof(ContextTest));

        [TestMethod]
        public void Test() {

            //输出 layout  %property{something}
            GlobalContext.Properties["something"] = "agv";

            log.Info("Entering application.");
            Bar bar = new Bar();
            bar.DoIt();
            log.Info("Exiting application.");

            new Thread(new ThreadStart(delegate()
            {
                ThreadContext.Properties["something"] = "thread_agv";
                log.Info("Entering application.");
                Bar bar2 = new Bar();
                bar2.DoIt();
                log.Info("Exiting application.");

            })).Start();
        }

    }
}
