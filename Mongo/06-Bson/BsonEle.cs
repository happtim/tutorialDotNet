using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;

namespace Mongo._06_Bson
{
    [TestClass]
    public class BsonEle {

        [TestMethod]
        public void Test() {
            var document = new BsonDocument();
            document.Add(new BsonElement("age", 21)); // OK, but next line is shorter
            document.Add("age", 21); // creates BsonElement automatically
        }
    }
}
