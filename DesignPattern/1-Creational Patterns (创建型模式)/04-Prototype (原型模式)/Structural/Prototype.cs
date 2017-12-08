using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._04_Prototype__原型模式_.Structural
{
    public interface Prototype {
        Prototype createClone();
        void call(string someone);
    }
}
