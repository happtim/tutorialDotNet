using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._18_Memento__备忘录模式_.Structural
{
    /// <summary>
    /// 备忘录,可以保存原发器内部状态
    /// </summary>
    public class Memento {
        public string state { get; set; }

        public Memento(Originator o) {
            state = o.state;
        }
    }
}
