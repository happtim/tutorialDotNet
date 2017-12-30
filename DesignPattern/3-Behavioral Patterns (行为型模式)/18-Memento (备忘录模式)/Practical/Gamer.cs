using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._18_Memento__备忘录模式_.Practical
{
    public class Gamer {
        private int money;
        private List<string> fruits = new List<string>();
        private Random random = new Random();
        private static string[] fruitsname = { "苹果", "葡萄", "香蕉", "橘子" };
        
        public Gamer(int money) {
            this.money = money;
        }

        public int Money { get { return money; } }

        public void bet() {
            int dice = random.Next(6) + 1;
            if(dice == 1) {
                money += 100;
                Console.WriteLine("所持有的金钱增加了...");
            }else if(dice == 2) {
                money /= 2;
                Console.WriteLine("所持有的金钱减半了...");
            }else if(dice == 6) {
                string f = getFruit();
                Console.WriteLine("获得水果(" + f + ")");
                fruits.Add(f);
            } else{
                Console.WriteLine("什么都没有发生");
            }
        }

        public Memento createMemento() {
            Memento m = new Memento(money);
            foreach(var f in fruits) {
                if(f.StartsWith("好吃的") ) {
                    m.AddFruit(f);
                }
            }
            return m;
        }

        public void restoreMemento(Memento memento) {
            this.money = memento.Money;
            this.fruits = memento.GetFruits();
        }

        public override string ToString() {
            return "[money = " + money + ", fruits = " + fruits + "]";
        }

        private string getFruit() {
            string prefix = "";
            if(random.NextDouble() > 0.5) {
                prefix = "好吃的";
            }
            return prefix + fruitsname[random.Next(fruitsname.Length)];
        }


    }
}
