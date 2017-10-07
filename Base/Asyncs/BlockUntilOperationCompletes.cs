using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Asyncs
{
    [TestClass]
    public class BlockUntilOperationCompletes {

        [TestMethod]
        public void Test() {

            string args = "127.0.0.1";
            // Start the asynchronous request for DNS information.
            // This example does not use a delegate or user-supplied object
            // so the last two arguments are null.
            IAsyncResult result = Dns.BeginGetHostEntry(args, null, null);
            Console.WriteLine("Processing your request for information...");
            // Do any additional work that can be done here.
            try
            {
                // EndGetHostByName blocks until the process completes.
                IPHostEntry host = Dns.EndGetHostEntry(result);
                string[] aliases = host.Aliases;
                IPAddress[] addresses = host.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine("Aliases");
                    for (int i = 0; i < aliases.Length; i++)
                    {
                        Console.WriteLine("{0}", aliases[i]);
                    }
                }
                if (addresses.Length > 0)
                {
                    Console.WriteLine("Addresses");
                    for (int i = 0; i < addresses.Length; i++)
                    {
                        Console.WriteLine("{0}", addresses[i].ToString());
                    }
                }
            } catch (SocketException e)
            {
                Console.WriteLine("An exception occurred while processing the request: {0}", e.Message);
            }
        }

    }
}
