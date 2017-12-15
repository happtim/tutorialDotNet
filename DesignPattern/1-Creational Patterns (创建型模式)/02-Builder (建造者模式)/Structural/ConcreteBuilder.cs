using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._02_Builder__建造者模式_.Structural
{
    public class ConcreteBuilder : Builder {

        public override void buildPart1() {
            this.product.Part1 = "build Part1";
        }

        public override void buildPart2() {
            this.product.Part2 = "build Part2";
        }

        public override void buildPart3() {
            this.product.Part3 = "build Part3";
        }

    }
}
