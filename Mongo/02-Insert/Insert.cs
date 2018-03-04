using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Mongo._02_Insert
{
    [TestClass]
    public class Insert {

        [TestMethod]
        public void Test() {
            var client = new MongoClient("mongodb://localhost:27017");

            var database = client.GetDatabase("agv");

            var collection = database.GetCollection<BsonDocument>("car_station");

            //插入一个文档
            collection.InsertOne(new BsonDocument {
                { "name", "MongoDB" },
                { "type", "Database" },
                { "count", 1 },
                { "info", new BsonDocument
                    {
                        { "x", 203 },
                        { "y", 102 }
                    }
                }
            });

            //插入许多文
            collection.InsertMany( 
                Enumerable.Range(0, 100).Select(i => new BsonDocument("counter", i))
            );
        }
    }
}
