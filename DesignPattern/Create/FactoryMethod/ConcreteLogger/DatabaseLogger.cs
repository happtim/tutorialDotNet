using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DesignPattern.Create.FactoryMethod.Framework;

namespace DesignPattern.Create.FactoryMethod.ConcreteLogger
{
    public class DatabaseLogger : Logger {

        public override void writeLog() {
            Console.WriteLine("数据库记录日志");
        }
    }
}
