using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DesignPattern.Create.FactoryMethod.Framework;
using DesignPattern.Create.FactoryMethod.ConcreteLogger;

namespace DesignPattern.Create.FactoryMethod.ConcreteFactory
{
    public class FileFactory : LoggerFactory
    {
        public override Logger createLogger() {
            return new FileLogger();
        }
    }
}
