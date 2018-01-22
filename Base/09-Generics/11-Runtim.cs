using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guide._09_Generics
{
    /// <summary>
    /// 当泛型在编译好后.就会标识元信息,代表他是泛型

    /// 值类型
    /// 当第一次使用值类型做参数,runtime会用过这个参数在合适地方替换msil.
    /// 
    /// 引用类型
    /// 当第一次使用引用类型做参数,runttim会生成这个类型的参数在合适地方替换msil.
    /// 当另一种引用出现时,还是的原来.由于所有的引用类型的大小都一样.
    /// </summary>
    class _11_Runtim
    {
    }
}
