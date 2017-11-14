using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._12_Proxy__代理模式_.Structural
{
    public class RealSubject : Subject {

        public RealSubject() {
            Console.WriteLine("Init Realsubject ...");
            Thread.Sleep(1000);
        }

        public override void Request() {
            Console.WriteLine("RealSubject Request1");
        }

        public override void SomeMethod() {
            Console.WriteLine("RealSubject Request2");
        }

        public override void SomeMethod2() {
            Console.WriteLine("RealSubject Request2");
        }
    }
}
