using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._21_Strategy__策略模式_.Practical
{
    public class MovieTicket {
        private double price;
        private Discount discount;

        public void setPrice(double price) {
            this.price = price;
        }

        public void setDiscount(Discount discount) {
            this.discount = discount;
        }

        public double getPrice() {
            return discount.calculate(this.price);
        }
    }
}
