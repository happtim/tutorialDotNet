using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._23_Visitor__访问者模式_.Practical2
{
    //访问者抽象类
    public abstract class Department {
        //声明一组重载的访问方法，用于访问不同类型的具体元素    
        public abstract void visit(FulltimeEmployee employee);
        public abstract void visit(ParttimeEmployee employee);
    }
}
