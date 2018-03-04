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
    public class BsonDoc {

        [TestMethod]
        public void Test() {

            //BsonDocument(IEnumerable<KeyValuePair<string, object>> dictionary);
            var doc = new BsonDocument
            {
                { "a", 1 },
                { "b", new BsonArray
                       {
                            new BsonDocument("c", 1)
                       }}
            };

        }
    }
}
