using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._09_Decorator__装饰模式_.Practical
{
    public class SideBorder : Border {

        private char borderChar;

        public SideBorder( Display display, char ch ): base(display) {
            borderChar = ch;
        }

        public override int getColumns() {
            return 1 + dispaly.getColumns() + 1;
        }

        public override int getRows() {
            return dispaly.getRows();
        }

        public override string getRowText(int row) {
            return borderChar + dispaly.getRowText(row) + borderChar;
        }
    }
}
