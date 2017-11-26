using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._19_Observer__观察者模式_.Structural
{
    public abstract class Subject {
        private List<Observer> observers = new List<Observer>();

        public void addObserver(Observer observer) {
            observers.Add(observer);
        }

        public void deleteObserver(Observer observer) {
            observers.Remove(observer);
        }

        public void notifyObservers() {

            foreach(var observer in observers) {
                observer.update(this);
            }
        }

        public abstract void getSubjectStatus();

    }
}
