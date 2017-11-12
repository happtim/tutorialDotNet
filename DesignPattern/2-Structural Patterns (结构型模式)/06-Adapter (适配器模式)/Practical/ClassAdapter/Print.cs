using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._06_Adapter__适配器模式_.Practical.ClassAdapter
{
    /// <summary>
    /// 最终实现接口,想做12V
    /// </summary>
    public interface Print {

        /// <summary>
        /// 弱化
        /// </summary>
        void printWeak();


        /// <summary>
        /// 强化
        /// </summary>
        void printStrong();
    }
}
