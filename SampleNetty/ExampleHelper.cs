using DotNetty.Common.Internal.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Console;

namespace SampleNetty
{
    public static class ExampleHelper
    {
        static ExampleHelper()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(ProcessDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string ProcessDirectory
        {
            get {
#if NETSTANDARD1_3
                return AppContext.BaseDirectory;
#else
                return AppDomain.CurrentDomain.BaseDirectory;
#endif
            }
        }

        public static IConfigurationRoot Configuration { get; }

        public static void SetConsoleLogger() => InternalLoggerFactory.DefaultFactory.AddProvider(new ConsoleLoggerProvider((s, level) => true, false));
    }
}
