using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._02_Builder__建造者模式_.Practical
{
    public class Director {
        private Builder builder;

        public Director(Builder builder) {
            this.builder = builder;
        }

        /// <summary>
        /// 编写文档
        /// </summary>
        public void construct() {
            builder.makeTitle("Greeting");
            builder.makeString("从早上到中午");
            builder.makeItems(new[] { "早上好.", "下午好." });
            builder.close();
        }

    }
}
