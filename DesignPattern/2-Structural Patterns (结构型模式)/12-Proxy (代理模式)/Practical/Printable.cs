using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._12_Proxy__代理模式_.Practical
{
    public interface Printable {
        void SetPrinterName(string name);
        string GetPrinterName();
        void Print(string something);
    }
}
