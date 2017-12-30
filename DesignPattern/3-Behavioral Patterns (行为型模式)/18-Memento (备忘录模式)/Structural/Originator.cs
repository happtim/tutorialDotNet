using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._18_Memento__备忘录模式_.Structural
{
    /// <summary>
    /// 原发器,可以创建memento,保存内部状态
    /// </summary>
    public class Originator {

        public string state { get; set; }

        public Originator() { }

        // 创建一个备忘录对象    
        public Memento createMemento() {
            return new Memento(this);
        }

        // 根据备忘录对象恢复原发器状态    
        public void restoreMemento(Memento m) {
            state = m.state;
        }

    }
}
