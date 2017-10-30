using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DesignPattern.Create.FactoryMethod.Framework;

namespace DesignPattern.Create.FactoryMethod.ConcreteLogger
{
    public class FileLogger : Logger
    {
        public override void writeLog() {
            Console.WriteLine("文件记录日志");
        }
    }
}
