using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._09_Decorator__装饰模式_.Practical
{
    public class StringDisplay : Display {

        private string name;

        public StringDisplay(string name) {
            this.name = name;
        }

        public override int getColumns() {
            return name.Length;
        }

        public override int getRows() {
            return 1;
        }

        public override string getRowText(int row) {
            if (row == 0)
                return name;
            else
                return null;
        }
    }
}
