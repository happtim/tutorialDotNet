using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._21_Strategy__策略模式_.Practical
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {
            MovieTicket mt = new MovieTicket();
            double originalPrice = 60.0;
            double currentPrice;

            mt.setPrice(originalPrice);
            Console.WriteLine("原始价格:" + originalPrice);

            Discount discount = new StudentDiscount();
            mt.setDiscount(discount);

            currentPrice = mt.getPrice();
            Console.WriteLine("折扣价格:" + currentPrice);

        }
    }
}
