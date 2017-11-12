using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._06_Adapter__适配器模式_.Practical.ClassAdapter
{
    /// <summary>
    /// 适配类
    /// </summary>
    public class PrintBanner : Banner, Print {

        public PrintBanner(string name):base(name) {

        }

        public void printStrong() {
            showWithParen();
        }

        public void printWeak() {
            showWithAStar();
        }
    }
}
