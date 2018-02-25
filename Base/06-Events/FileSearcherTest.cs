using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpGuide._06_Events
{
    [TestClass]
    public class FileSearcherTest {

        [TestMethod]
        public void Test() {

            FileSearcher searcher= new FileSearcher();
            EventHandler<FileFoundArgs> onFileFound = (sender, eventArgs) =>
                Console.WriteLine(eventArgs.FoundFile);
            searcher.FileFound += onFileFound;
            searcher.Search(".", "*");
        }
    }
}
