using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._06_Adapter__适配器模式_.Practical.ClassAdapter
{
    /// <summary>
    /// 代表要适配的类,可以想做220V电压
    /// </summary>
    public class Banner {

        private string name;
        public Banner(string name) {
            this.name = name;
        }

        public void showWithParen() {
            Console.WriteLine("(" + name + ")");
        }

        public void showWithAStar() {
            Console.WriteLine("*" + name + "*");
        }
    }
}
