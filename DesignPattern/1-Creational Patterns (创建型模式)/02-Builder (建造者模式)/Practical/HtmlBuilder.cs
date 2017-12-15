using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._02_Builder__建造者模式_.Practical
{
    public class HtmlBuilder : Builder {
        private string filename;
        private StreamWriter writer;

        public override void close() {
            writer.WriteLine("</body></html>");
            writer.Close();
        }

        public override void makeItems(string[] items) {
            writer.WriteLine("<ul>");
            for(int i = 0; i< items.Length; i++) {
                writer.WriteLine("<li>" + items[i] + "</li>");
            }
            writer.WriteLine("</ul>");
        }

        public override void makeString(string str) {
            writer.WriteLine("<p>" + str + "</p>");
        }

        public override void makeTitle(string title) {
            filename = title + ".html";
            writer = new StreamWriter(filename);
            writer.WriteLine("<html><head><title>" + title + "</title></head><body>");
            writer.WriteLine("<h1>" + title + "</h1>");
        }

        public string getResult() {
            return filename;
        }
    }
}
