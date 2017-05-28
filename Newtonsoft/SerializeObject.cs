using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Newtonsoft
{
    [TestClass]
    public class SerializeObject
    {
        [TestMethod]
        public void test()
        {
            Account account = new Account
            {
                Email = "james@example.com",
                Active = true,
                CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                Roles = new List<string> {
                    "User",
                    "Admin"
                }
            };

            Console.WriteLine(
                JsonConvert.SerializeObject(account, Formatting.Indented)
            );

        }
    }
}
