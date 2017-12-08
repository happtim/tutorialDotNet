﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._1_Creational_Patterns__创建型模式_._04_Prototype__原型模式_.Practical
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {
            Manager manager = new Manager();
            UnderlinePen upen = new UnderlinePen('~');
            MessageBox mbox = new MessageBox('*');
            MessageBox sbox = new MessageBox('/');

            manager.register("strong message", upen);
            manager.register("warning box", mbox);
            manager.register("slash box", sbox);

            Product p1 = manager.create("strong message");
            p1.use("Hello World.");
            Product p2 = manager.create("warning box");
            p2.use("Hello World.");
            Product p3 = manager.create("slash box");
            p3.use("Hello World.");
            
        }
    }
}
