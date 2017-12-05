﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._21_Strategy__策略模式_.Practical
{
    public class VipDiscount : Discount {

        public override double calculate(double price) {
            Console.WriteLine("VIP票:");
            Console.WriteLine("增加积分!");
            return price * 0.5;
        }
    }
}
