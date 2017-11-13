using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._09_Decorator__装饰模式_.Practical
{
    public class FullBorder : Border
    {

        public FullBorder(Display display) : base(display) {

        }

        public override int getColumns() {
            return 1 + dispaly.getColumns() + 1;
        }

        public override int getRows() {
            return 1 + dispaly.getRows() + 1;
        }

        public override string getRowText(int row) {
            if (row == 0)
                return "+" + makeLine('-', dispaly.getColumns()) + "+";
            else if (row == dispaly.getRows() + 1)
                return "+" + makeLine('-', dispaly.getColumns()) + "+";
            else
                return "|" + dispaly.getRowText(row - 1) + "|";
        }

        private string makeLine(char ch , int count) {
            string str = "";
            for( int i = 0; i< count; i++) {
                str += ch;
            }
            return str;
        }
    }
}
