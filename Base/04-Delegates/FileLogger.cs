using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpGuide._04_Delegates
{
    public class FileLogger {
        private readonly string logPath;

        public FileLogger(string path) {
            logPath = path;
            Logger.WriteMessage += LogMessage;

        }

        public void DetachLog() => Logger.WriteMessage -= LogMessage;

        private void LogMessage(string msg) {
            try {
                using(var log = File.AppendText(logPath)) {
                    log.WriteLine(msg);
                    log.Flush();
                }
            } catch(Exception ex) {
            }
        }
    }
}
