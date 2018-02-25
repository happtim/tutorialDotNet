using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGuide._06_Events
{
    public class FileFoundArgs : EventArgs {

        public string FoundFile { get; }

        public FileFoundArgs(string fileName)
        {
            FoundFile = fileName;
        }
    }
}
