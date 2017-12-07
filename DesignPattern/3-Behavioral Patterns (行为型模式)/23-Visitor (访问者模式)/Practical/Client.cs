using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._23_Visitor__访问者模式_.Practical
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {
            Console.WriteLine("making root entries...");
            Directory rootdir = new Directory("root");
            Directory bindir = new Directory("bin");
            Directory usrdri = new Directory("usr");
            Directory tmpdir = new Directory("tmp");
            Directory homedir = new Directory("home");

            rootdir.add(bindir);
            rootdir.add(usrdri);
            rootdir.add(tmpdir);
            rootdir.add(homedir);

            bindir.add(new File("vi", 10000));
            bindir.add(new File("latex", 20000));
            rootdir.accept(new ListVisitor());

            Console.WriteLine();
            Console.WriteLine("making user entries...");
            Directory tim = new Directory("tim");
            Directory tom = new Directory("tom");
            Directory sam = new Directory("sam");

            homedir.add(tim);
            homedir.add(tom);
            homedir.add(sam);

            tim.add(new File("diary.html", 100));
            tim.add(new File("composite.java", 200));
            tom.add(new File("memo.text", 300));
            sam.add(new File("game.doc", 400));
            sam.add(new File("junk.mail", 500));

            rootdir.accept(new ListVisitor());
            
        }
    }
}
