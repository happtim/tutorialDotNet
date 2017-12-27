using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._11_Flyweight__享元模式_.Structural
{
    public class FlyweightFactory {
        private Dictionary<string, Flyweight> pool = new Dictionary<string, Flyweight>();

        public Flyweight getFlyweight(string name) {
            if (pool.ContainsKey(name)) {
                return pool[name];
            } else {
                Flyweight fly = new Flyweight();
                pool.Add(name, fly);
                return fly;
            }

        }

    }
}
