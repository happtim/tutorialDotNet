using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Generics
{

    public class Animal {
        public string Name { get; set; }
    }

    public class Fish : Animal {
        public Animal animal = null;
        public new string Name { get { return animal.Name; } }
    }

    public class MyList<T> : IList<T> where T : Animal {

        public List<T> Animals { get; set; } = new List<T>();

        public T this[int index] {
            get { return Animals[index]; }
            set { Animals[index] = value; }
        }

        public int Count {
            get { return Animals.Count; }
        }

        public bool IsReadOnly {
            get { return false; }
        }

        public void Add(T item) {
            Animals.Add(item);
        }

        public void Clear() {
            Animals.Clear();
        }

        public bool Contains(T item) {
            return Animals.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex) {
            Animals.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator() {
            return Animals.GetEnumerator();
        }

        public int IndexOf(T item) {
            return Animals.IndexOf(item);
        }

        public void Insert(int index, T item) {
            Animals.Insert(index, item);
        }

        public bool Remove(T item) {
            return Animals.Remove(item);
        }

        public void RemoveAt(int index) {
            Animals.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            throw new NotImplementedException();
        }

        public T GetFirst() {
            String name = Animals.First().Name;
            return Animals.First();
        }

        public String GetFirstName() {
            return Animals.First().Name;
        }
    }

    [TestClass]
    public class ListTest {

        [TestMethod]
        public void Test() {

            Fish f1 = new Fish{ animal = new Animal { Name = "Tim" } };
            Fish f2 = new Fish{ animal = new Animal { Name = "Tom" } };
            Fish f3 = new Fish{ animal = new Animal { Name = "Sam" } };

            MyList<Fish> Fishes = new MyList<Fish> {
                f1,f2,f3
            };

            Assert.AreEqual(Fishes.GetFirst().Name, "Tim");
            //在泛型里面只能知道自己是Animal .不能获取到集成类的信息
            Assert.AreEqual(Fishes.GetFirstName(), null);

        }
    }
}
