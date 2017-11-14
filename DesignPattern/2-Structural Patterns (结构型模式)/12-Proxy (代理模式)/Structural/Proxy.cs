using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._12_Proxy__代理模式_.Structural
{
    public class Proxy : Subject {

        private RealSubject real;

        public override void Request() {
            if(real == null) {
                real = new RealSubject();
            }

            real.Request();
        }

        public override void SomeMethod() {
            Console.WriteLine("SomeMethod");
        }

        public override void SomeMethod2() {
            Console.WriteLine("SomeMethod2");
        }
    }
}
