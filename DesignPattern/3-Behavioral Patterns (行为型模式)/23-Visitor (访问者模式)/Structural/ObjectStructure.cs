using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._23_Visitor__访问者模式_.Structural
{
    public class ObjectStructure {
        private List<Element> list = new List<Element>();

        public void accept(Visitor visitor) {
            foreach(var v in list) {
                v.accept(visitor);
            }
        }

        public void addElement(Element element) {
            list.Add(element);
        }

        public void removeElement(Element element) {
            list.Remove(element);
        }
    }
}
