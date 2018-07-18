using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebTest
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public List<BaseTaskDTO> NonExecuateTask() {
            return new List<BaseTaskDTO>() {
                new BaseTaskDTO() { FromStation = "00001",ToStation = "00002",Priority = 10, CreateTime = DateTime.Now },
                new BaseTaskDTO() { FromStation = "20002",ToStation = "20003",Priority = 20, CreateTime = DateTime.Now },
                new BaseTaskDTO() { FromStation = "40004",ToStation = "40005",Priority = 30, CreateTime = DateTime.Now },
            };
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Add(int a, int b) {
            return a + b;
        }
    }
}
