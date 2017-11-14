using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._12_Proxy__代理模式_.Practical
{
    public class Printer : Printable {

        private string name;

        public Printer() {
            HeavyJob("Printer Init Begin.");
        }

        public Printer(string name) {
            this.name = name;
            HeavyJob("Printer Init Begin.");
        }

        private void HeavyJob(string msg) {
            Console.WriteLine(msg);
            for(int i = 0; i< 5; i++) {
                Thread.Sleep(1000);
                Console.Write(".");
            }
            Console.WriteLine("End Init.");

        }

        public string GetPrinterName() {
            return name;
        }

        public void Print(string something) {
            Console.WriteLine("====" + name + " Use Printer ====");
            Console.WriteLine(something);
        }

        public void SetPrinterName(string name) {
            this.name = name;
        }
    }
}
