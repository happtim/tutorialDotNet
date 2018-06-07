using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netty
{
    public static class ServerSettings
    {
        public static bool IsSsl
        {
            get {
                string ssl = ExampleHelper.Configuration["ssl"];
                return !string.IsNullOrEmpty(ssl) && bool.Parse(ssl);
            }
        }

        public static int Port => int.Parse(ExampleHelper.Configuration["port"]);

        public static bool UseLibuv
        {
            get {
                string libuv = ExampleHelper.Configuration["libuv"];
                return !string.IsNullOrEmpty(libuv) && bool.Parse(libuv);
            }
        }
    }
}
