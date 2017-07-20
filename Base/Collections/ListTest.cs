using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Collections
{

    class People {
        public string Name { get; set; }

        public override bool Equals(object obj) {

            if (this == null)
                throw new NullReferenceException("People can't be null");

            People people = obj as People;
            if (people == null)
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            Console.WriteLine("call people's Equals(object) method");

            return this.Name == people.Name;
        }

        public bool Equals(People people) {

            if(this == null)
                throw new NullReferenceException("People can't be null");

            if (people == null)
                return false;

            if (Object.ReferenceEquals(this, people))
                return true;

            Console.WriteLine("call people's Equals(People) method");

            return this.Name == people.Name;
        }

    }

    [TestClass]
    public class ListTest {

        List<People> list = new List<People>() {
            new People {Name = "tim" },
            new People {Name = "tom" },
            new People {Name = "sam" },
        };

        [TestMethod]
        public void testIndexOf() {

            int index = 
            list.IndexOf(new People { Name = "tom" });

            Console.Write(index);
        }

        [TestMethod]
        public void testContains() {

            bool found = list.Contains(new People { Name = "tom" });
            Console.Write(found);

        }

    }
}
