using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Events
{

    [TestClass()]
    public class PublishEvents
    {
        [TestMethod()]
        public void test() {
            Publisher publisher = new Publisher();
            Subscriber subscriber = new Subscriber(publisher);
            Subscriber subscriber2 = new Subscriber(publisher);
            publisher.DoSomething();
        }
    }

    class Publisher
    {
        public event EventHandler RaiseEvent;

        public virtual void OnRaiseEvent(EventArgs e)
        {
            EventHandler handle = RaiseEvent;

            if (handle != null) {
                handle(this, e);
            }
        }

        public void DoSomething()
        {
            OnRaiseEvent(new EventArgs());
        }
    }

    class Subscriber
    {

        public Subscriber(Publisher publisher) {
            publisher.RaiseEvent += EventHandler;
        }

        public void EventHandler(object sender ,EventArgs e) {
            Console.WriteLine("received message");
        }
    }


}
