using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._02_Builder__建造者模式_.Practical
{
    public class TextBuilder : Builder {

        private StringBuilder buffer = new StringBuilder();

        public override void close() {
            buffer.Append("===============================\r\n");
        }

        public override void makeItems(string[] items) {

            for(int i = 0; i < items.Length; i++) {
                buffer.Append("  ." + items[i] + "\r\n");
            }
        }

        public override void makeString(string str) {
            buffer.Append("." + str + "\r\n");
            buffer.Append("\r\n");
        }

        public override void makeTitle(string title) {
            buffer.Append("===============================\r\n");
            buffer.Append("[" + title + "]");
            buffer.Append("\r\n");
        }

        public string getResult() {
            return buffer.ToString();
        }

    }
}
