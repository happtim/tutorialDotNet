using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using DesignPattern.Create.FactoryMethod.ConcreteFactory;
using DesignPattern.Create.FactoryMethod.Framework;


namespace DesignPattern.Create.FactoryMethod
{
    [TestClass]
    public class Test {

        [TestMethod]
        public void test() {
            LoggerFactory factory = new FileFactory(); //可引入配置文件实现    
            Logger logger = factory.createLogger();
            logger.writeLog();
        }
    }
}
