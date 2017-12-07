using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._23_Visitor__访问者模式_.Practical
{
    public class ListVisitor : Visitor {

        private string currentDir = "";

        public override void visit(Directory directory) {
            Console.WriteLine(currentDir + "/" + directory);

            string saveDir = currentDir;
            currentDir = currentDir + "/" + directory.getName();
            foreach(Entry entry in directory) {
                entry.accept(this);
            }
            currentDir = saveDir;
            
        }

        public override void visit(File file) {
            Console.WriteLine(currentDir + "/" + file);

        }

    }
}
