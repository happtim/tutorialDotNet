using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebTest.ServiceReference1;

namespace WebTest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //正常的方式调用
        protected void Button1_Click(object sender, EventArgs e) {
            var soap = new WebService1SoapClient();
            
            Label1.Text = soap.Add(1, 2).ToString();

            var list = soap.NonExecuateTask();
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        //使用QWebServiceProxy调用
        protected void Button2_Click(object sender, EventArgs e)
        {
            var proxy = new QWebServiceProxy("http://localhost:8080/WebService1.asmx?WSDL", "WebTest", "WebService1");
            var result =  proxy.Invoke("Add", new object[] {3,5});
            Label1.Text = result.ToString();

            object list =  proxy.Invoke("NonExecuateTask",new object[] { });

            GridView1.DataSource = list;
            
            GridView1.DataBind();

            
        }
    }
}