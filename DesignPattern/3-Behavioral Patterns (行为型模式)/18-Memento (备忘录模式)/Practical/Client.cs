using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._18_Memento__备忘录模式_.Practical
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {
            Gamer gamer = new Gamer(100);
            Memento memento = gamer.createMemento();

            for(int i = 0; i < 100; i++) {
                Console.WriteLine("---------------- " + i);
                Console.WriteLine("当前状态:" + gamer);

                gamer.bet();

                Console.WriteLine("所持有金额" + gamer.Money + "元");
                if(gamer.Money  > memento.Money) {
                    Console.WriteLine("持有的金额增加了许多,所以保存了游戏的当前状态");
                    memento = gamer.createMemento();
                }else if(gamer.Money <  memento.Money / 2) {
                    Console.WriteLine("持有的金额减少了许多,所以恢复了游戏的之前状态");
                    gamer.restoreMemento(memento);
                }

                Thread.Sleep(100);
                Console.WriteLine();
            }
        }
    }
}
