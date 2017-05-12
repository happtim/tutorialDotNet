using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Tutorial.Sockets
{
    class SynchronousSocketListener
    {
        public static string data = null;

        public static void StartListening() {
            byte[] bytes = new Byte[1024];

            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            try {
                listener.Bind(localEndPoint);
                //10 queued can acceptance
                listener.Listen(10);

                while (true) {
                    Console.WriteLine("Waiting for a connection...");
                    Socket handler = listener.Accept();

                    data = null;

                    while (true) {
                        bytes = new byte[1024];
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if(data.IndexOf("<EOF>") > 1) {
                            break;
                        }
                    }

                    Console.WriteLine("Text received : {0}", data);
                    byte[] msg = Encoding.ASCII.GetBytes(data);
                    int byteSend = handler.Send(msg);
                    Console.WriteLine("Server send {0} bytes data to Client", byteSend);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            } catch(Exception e) {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue ...");
            Console.Read();
                
        }

    }
}
