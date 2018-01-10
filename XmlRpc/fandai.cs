using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CookComputing.XmlRpc;
/*
//python xmlrpc server

from SimpleXMLRPCServer import SimpleXMLRPCServer  
global a  
  
def load():  
    global a  
    a = [1 ,2, 24]  
    return a  
  
def findai(i):  
    global a  
    print a[i]  
    return a[i]  
  
server = SimpleXMLRPCServer(("localhost", 8000))  
server.register_function(findai,"findai")  
load()  
server.serve_forever()   
*/

namespace XmlRpc
{
    [XmlRpcUrl("http://localhost:8000/")]
    public interface fandai : IXmlRpcProxy {

        [XmlRpcMethod]
        int findai(int i);
    }
}
