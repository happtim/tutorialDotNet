﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._01_Abstract_Factory__抽象工厂模式_.Practical
{
    /// <summary>
    /// 豪华型套餐,包括鸡腿和咖啡
    /// </summary>
    public class LuxuryPackageFactory : KFCFactory {

        public override KFCDrink CreateDrink() {
            return new Coffee();
        }

        public override KFCFood CreateFood() {
            return new Chicken();
        }
    }
}
