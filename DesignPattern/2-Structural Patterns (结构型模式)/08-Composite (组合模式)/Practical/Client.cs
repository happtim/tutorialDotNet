using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._08_Composite__组合模式_.Practical
{
    [TestClass]
    public  class Client {

        [TestMethod]
        public void Test() {
            Directory rootdir = new Directory("root");
            Directory bindir = new Directory("bin");
            Directory tmpdir = new Directory("bin");
            Directory usrdir = new Directory("usr");
            rootdir.Add(bindir);
            rootdir.Add(tmpdir);
            rootdir.Add(usrdir);
            bindir.Add(new File("vi", 10000));
            bindir.Add(new File("latex", 20000));
            rootdir.printList();
        }
    }
}
