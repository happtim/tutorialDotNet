using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Linq
{
    [TestClass]
    public class Join
    {
        [TestMethod]
        public  void testJoin1()
        {
            // Array 1.
            var ints1 = new int[3];
            ints1[0] = 4;
            ints1[1] = 3;
            ints1[2] = 0;

            // Array 2.
            var ints2 = new int[3];
            ints2[0] = 5;
            ints2[1] = 4;
            ints2[2] = 2;

            {
                var result = 
                ints1.Join<int, int, int, int>(ints2,o => o + 1, i => i, (o, i) => o);

                foreach(var i in result)
                {
                    Console.WriteLine(i);
                    //4,3
                }
            }

            {
                //equals previous 
                var result =
                    from t in ints1
                    join x in ints2 on (t + 1) equals x
                    select t;

                    foreach(var i in result)
                    {
                        Console.WriteLine(i);
                        //4,3
                    }
            }

        }

        class Customer
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        class Order
        {
            public int ID { get; set; }
            public string Product { get; set; }
        }


        [TestMethod]
        public void testJoin2()
        {
            // Example customers.
            var customers = new Customer[]
            {
                new Customer{ID = 5, Name = "Sam"},
                new Customer{ID = 6, Name = "Dave"},
                new Customer{ID = 7, Name = "Julia"},
                new Customer{ID = 8, Name = "Sue"}
            };

            // Example orders.
            var orders = new Order[]
            {
                new Order{ID = 5, Product = "Book"},
                new Order{ID = 6, Product = "Game"},
                new Order{ID = 7, Product = "Computer"},
                new Order{ID = 8, Product = "Shirt"}
            };

            var query = from c in customers
                        join o in orders on c.ID equals o.ID
                        select new { c.Name, o.Product };

            foreach (var group in query)
            {
                Console.WriteLine("{0} bought {1}", group.Name, group.Product);
            }


        }

    }
}
