using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._12_Proxy__代理模式_.Practical
{
    public class PrinterProxy : Printable {

        private string name;
        private Printer real;

        public PrinterProxy(string name) {
            this.name = name;
        }

        public string GetPrinterName() {
            return this.name;
        }

        public void SetPrinterName(string name) {
            if(real != null) {
                real.SetPrinterName(name);
            }
            this.name = name;
        }

        public void Print(string something) {
            Realize();
            real.Print(something);
        }

        public void Realize() {
            if(real == null) {
                real = new Printer(name);
            }
        }
    }
}
