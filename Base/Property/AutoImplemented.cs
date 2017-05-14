using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Base.Property
{
    [TestClass()]
    public class AutoImplemented
    {
        [TestMethod()]
        public void test() {
            // Intialize a new object.
            Customer cust1 = new Customer(4987.63, "Northwind", 90108);

            //Modify a property
            cust1.TotalPurchases += 499.99;

            Assert.AreEqual(
                4987.63 + 499.99,
                cust1.TotalPurchases
            );

        }
    }

    // C# 3.0 之后， 如果没有等多的逻辑添加再get；set；
    //方法中就可以使用简便方式,编译器会自动生成成员变量
    class Customer
    {
        // Auto-Impl Properties for trivial get and set
        public double TotalPurchases { get; set; }
        public string Name { get; set; }
        public int CustomerID { get; set; }

        // Constructor
        public Customer(double purchases, string name, int ID)
        {
            TotalPurchases = purchases;
            Name = name;
            CustomerID = ID;
        }
        // Methods
        public string GetContactInfo() { return "ContactInfo"; }
        public string GetTransactionHistory() { return "History"; }

        // .. Additional methods, events, etc.
    }
}
