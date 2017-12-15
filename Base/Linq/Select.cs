using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Linq
{
    [TestClass]
    public class Select
    {
        [TestMethod]
        //对每个元素做个运算,这个方法比较优雅
        public void testSelect()
        {
            string[] array = { "cat", "dog", "mouse" };

            var result = array.Select(element => element.ToUpper());

            foreach( string value in result)
            {
                Console.WriteLine(value);
            }
        }

        class PetOwner
        {
            public string Name { get; set; }
            public List<String> Pets { get; set; }
        }

        [TestMethod]
        //将一个集合的东西变平然后整合成一个列表
        public void testSelectMany() {
            PetOwner[] petOwners =
                 { new PetOwner { Name="Higa, Sidney",
                       Pets = new List<string>{ "Scruffy", "Sam" } },
                   new PetOwner { Name="Ashkenazi, Ronen",
                       Pets = new List<string>{ "Walker", "Sugar" } },
                   new PetOwner { Name="Price, Vernette",
                       Pets = new List<string>{ "Scratches", "Diesel" } } };

            IEnumerable<string> query1 = petOwners.SelectMany(petOwner => petOwner.Pets);

            Console.WriteLine("Using SelectMany():");

            // Only one foreach loop is required to iterate 
            // through the results since it is a
            // one-dimensional collection.
            foreach (string pet in query1) {
                Console.WriteLine(pet) ;
            }

        }
    }
}
