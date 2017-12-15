using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._02_Builder__建造者模式_.Practical
{
    public abstract class Builder {

        public abstract void makeTitle(string title);
        public abstract void makeString(string str);
        public abstract void makeItems(string [] items);
        public abstract void close();

    }
}
