using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._02_Builder__建造者模式_.Structural
{
    public abstract class Builder {

        protected Product product = new Product();

        public abstract void buildPart1();
        public abstract void buildPart2();
        public abstract void buildPart3();

        public Product getResult() {
            return product;
        }

    }
}
