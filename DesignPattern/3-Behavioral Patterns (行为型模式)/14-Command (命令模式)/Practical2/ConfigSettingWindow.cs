using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._14_Command__命令模式_.Practical2
{
    /// <summary>
    /// 配置文件设置窗口类：请求发送者  
    /// </summary>
    public class ConfigSettingWindow {

        private List<Command> commands = new List<Command>();
        private Command command;

        public void SetCommnad(Command command) {
            this.command = command;
        }

        public void Call(string args) {
            command.execute(args);
            commands.Add(command);
        }

        public void Save() {
            FileStream fs = new FileStream("Commands.data", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, commands);
            fs.Close();
        }

        public void Recover() {
            FileStream fs = new FileStream("Commands.data", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            commands = (List<Command>)  bf.Deserialize(fs);
            fs.Close();

            foreach(var command in commands) {
                command.execute();
            }
        }

    }
}
