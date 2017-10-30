using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Create.FactoryMethod.Framework
{
    public abstract class LoggerFactory {
        public abstract Logger createLogger();
    }
}
