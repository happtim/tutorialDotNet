using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/***

    edit SampleDotfuscator.csproj

	<Target Name="AfterBuild"  Condition="'$(Configuration)' == 'Release'" >
		<Exec Command="&quot;$(DevEnvDir)Extensions\PreEmptiveSolutions\DotfuscatorCE\dotfuscatorCLI.exe&quot; Dotfuscator1.xml" />
	</Target>

***/

namespace SampleDotfuscator
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            int a = 1;
            int b = a + 100;
            Console.WriteLine( string.Format("Hello World! b = {0}",b));
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
