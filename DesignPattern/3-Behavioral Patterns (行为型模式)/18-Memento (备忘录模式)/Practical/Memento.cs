using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._18_Memento__备忘录模式_.Practical
{
    public class Memento {
        private int money = 0;
        private List<string> fruits = new List<string>();

        public int Money { get { return money; } }

        public Memento(int money) {
            this.money = money;
        }

        public void AddFruit(string fruit) {
            fruits.Add(fruit);
        }

        public List<string> GetFruits() {
            return fruits;
        }

    }
}
