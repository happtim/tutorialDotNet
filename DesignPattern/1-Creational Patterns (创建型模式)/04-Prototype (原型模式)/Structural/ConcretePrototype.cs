using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._04_Prototype__原型模式_.Structural
{
    public class ConcretePrototype : Prototype {
        private string name;
        public ConcretePrototype(string name) {
            this.name = name;
        }
        public string Name { get { return name; } }

        public Prototype createClone() {
            Prototype obj =  (Prototype) this.MemberwiseClone();
            return obj;
        }

        public void call(string someone) {
            Console.WriteLine(this.name + " Call " + someone);
        }
    }
}
