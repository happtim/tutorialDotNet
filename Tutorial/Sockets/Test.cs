using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tutorial.Sockets
{
    class Test
    {
        public static void Main(string[] args) {

            new Thread(SynchronousSocketClient.StartClient).Start();
            SynchronousSocketListener.StartListening();

        }
    }
}
