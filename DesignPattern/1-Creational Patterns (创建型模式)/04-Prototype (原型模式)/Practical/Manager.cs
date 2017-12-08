using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._04_Prototype__原型模式_.Practical
{
    public class Manager {
        private Dictionary<string, Product> showcase = new Dictionary<string, Product>();
        public void register(string name,Product proto) {
            showcase.Add(name, proto);
        }
        public Product create(string protoname) {
            Product p = showcase[protoname];
            return (Product)p.Clone();
        }
    }
}
