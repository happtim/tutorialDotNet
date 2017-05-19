using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityFramework.SampleOne
{
    public class LoggerPeople : IPeople
    {
        private IPeople people;
        private ILogger logger;

        public LoggerPeople(IPeople people, ILogger logger) {
            this.people = people;
            this.logger = logger;
        }

        public void DrinkWater()
        {
            people.DrinkWater();
            logger.WriteLog("记录了下日志");
        }
    }
}
