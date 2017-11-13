using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._09_Decorator__装饰模式_.Practical
{
    public abstract class Display {

        public abstract int getColumns();
        public abstract int getRows();
        public abstract string getRowText(int row);

        public void show() {
            for(int i = 0; i < getRows(); i++) {
                Console.WriteLine(getRowText(i));
            }
        }
    }
}
