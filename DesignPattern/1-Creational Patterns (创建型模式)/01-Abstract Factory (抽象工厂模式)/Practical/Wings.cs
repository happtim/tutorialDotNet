﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._01_Abstract_Factory__抽象工厂模式_.Practical
{
    public class Wings : KFCFood
    {
        public override void Display() {
            Console.WriteLine("鸡翅");
        }
    }
}
