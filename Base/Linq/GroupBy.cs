using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Linq
{
    [TestClass]
    public class GroupBy
    {
        class Pet
        {
            public string Name { get; set; }
            public double Age { get; set; }
        }

        [TestMethod]
        public void testGroupBy()
        {
            // Create a list of pets.
            List<Pet> pets =
                new List<Pet>{ new Pet { Name="Barley", Age=8 },
                       new Pet { Name="Boots", Age=4 },
                       new Pet { Name="Whiskers", Age=1 },
                       new Pet { Name="Daisy", Age=4 } };

            // Group the pets using Age as the key value 
            // and selecting only the pet's Name for each value.
            IEnumerable<IGrouping<double, Pet>> query =
                pets.GroupBy(pet => pet.Age, pet => pet);

            // Iterate over each IGrouping in the collection.
            foreach (IGrouping<double, Pet> petGroup in query)
            {
                // Print the key value of the IGrouping.
                Console.WriteLine(petGroup.Key);
                // Iterate over each value in the 
                // IGrouping and print the value.
                foreach (Pet pet in petGroup)
                    Console.WriteLine("  {0}", pet.Name);
            }
        }
        /*
         This code produces the following output:

         8
           Barley
         4
           Boots
           Daisy
         1
           Whiskers
        */

        [TestMethod]
        //可以对枚举的值,经行一些计算
        public void testGroup2()
        {
            // Create a list of pets.
            List<Pet> petsList =
                new List<Pet>{ new Pet { Name="Barley", Age=8.3 },
                                new Pet { Name="Boots", Age=4.9 },
                                new Pet { Name="Whiskers", Age=1.5 },
                                new Pet { Name="Daisy", Age=4.3 } };

            // Group Pet.Age values by the Math.Floor of the age.
            // Then project an anonymous type from each group
            // that consists of the key, the count of the group's
            // elements, and the minimum and maximum age in the group.
            var query = petsList.GroupBy(
                pet => Math.Floor(pet.Age),
                pet => pet.Age,
                (baseAge, ages) => new
                {
                    Key = baseAge,
                    Count = ages.Count(),
                    Min = ages.Min(),
                    Max = ages.Max()
                });

            // Iterate over each anonymous type.
            string outputBlock = "";
            foreach (var result in query)
            {
                outputBlock += "\nAge group: " + result.Key + "\n";
                outputBlock += "Number of pets in this age group: " + result.Count + "\n";
                outputBlock += "Minimum age: " + result.Min + "\n";
                outputBlock += "Maximum age: " + result.Max + "\n";
            }

            Console.WriteLine(outputBlock);

        }

    }
}
