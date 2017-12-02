using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._14_Command__命令模式_.Practical2
{
    /// <summary>
    /// 请求接收者。由于ConfigOperator类的对象是Command的成员对象，它也将随Command对象一起写入文件，因此ConfigOperator也需要实现Serializable接口
    /// </summary>
    [Serializable]
    public class ConfigOperator {
        public void insert(String args)
        {
            Console.WriteLine("增加新节点：" + args);
        }

        public void modify(String args)
        {
            Console.WriteLine("修改节点：" + args);
        }

        public void delete(String args)
        {
            Console.WriteLine("删除节点：" + args);
        }
    }
}
