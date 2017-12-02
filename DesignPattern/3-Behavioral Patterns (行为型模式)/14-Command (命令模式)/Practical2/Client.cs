using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._14_Command__命令模式_.Practical2
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {
            //新增Invoker
            ConfigSettingWindow csw = new ConfigSettingWindow();
            Command command = null;
            //新建Receiver 接收发送来的消息
            ConfigOperator configOperator = new ConfigOperator();

            //新增命令
            command = new InsertCommand("增加", "");
            //设置Receiver
            command.SetConfigOperator(configOperator);
            //Invoker设置command
            csw.SetCommnad(command);
            //调用
            csw.Call("网站首页");

            command = new ModifyCommand("修改", "");
            command.SetConfigOperator(configOperator);
            csw.SetCommnad(command);
            csw.Call("端口号");

            command = new DeleteCommand("删除", "");
            command.SetConfigOperator(configOperator);
            csw.SetCommnad(command);
            csw.Call("端口号");

            Console.WriteLine("----------------------");
            Console.WriteLine("保存配置");
            csw.Save();

            Console.WriteLine("----------------------");
            Console.WriteLine("恢复配置");
            csw.Recover();


        }
    }
}
