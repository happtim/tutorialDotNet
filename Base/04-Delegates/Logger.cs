using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGuide._04_Delegates
{
    // Logger implementation two
    public enum Severity
    {
        Verbose,
        Trace,
        Information,
        Warning,
        Error,
        Critical
    }

    public static class Logger {

        //声明writeMessage类型为委托 有一个参数为string
        public static Action<string> WriteMessage;

        public static Severity LogLevel { get; set; } = Severity.Warning;

        public static void LogMessage(Severity s, string component, string msg)
        {
            if (s < LogLevel)
                return;

            var outputMsg = $"{DateTime.Now}\t{s}\t{component}\t{msg}";
            WriteMessage(outputMsg);
        }

    }
}
