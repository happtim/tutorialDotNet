using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._02_Builder__建造者模式_.Structural
{
    public class Director {
        private Builder builder;
        public Director(Builder builder) {
            this.builder = builder;
        }

        public Product construct() {
            builder.buildPart1();
            builder.buildPart2();
            builder.buildPart3();
            return builder.getResult();
        }

    }
}
