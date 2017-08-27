using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AutofacIOC.Comm
{
    public class ConfigReader :IConfigReader{

        private string sectionName ;

        public ConfigReader(string configSectionName) {
            sectionName = configSectionName;
        }

        public string read() {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[sectionName] ?? "Not Found";
            return result;
        }

    }
}
