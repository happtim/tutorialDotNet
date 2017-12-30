using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._18_Memento__备忘录模式_.Structural
{
    /// <summary>
    /// 管理者，它负责保存备忘录
    /// </summary>
    public class Caretaker {
        private Memento memento;

        public Memento getMemento() {
            return memento;
        }

        public void setMemento(Memento memento) {
            this.memento = memento;
        }
    }
}
