using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Mongo
{
    [TestClass]
    public class Connection {

        [TestMethod]
        public void Test() {
            var client = new MongoClient("mongodb://localhost:27017");

            var database = client.GetDatabase("agv");

            var collection = database.GetCollection<BsonDocument>("car_station");

            var count = collection.Count(new BsonDocument());

            var documents = collection.Find(new BsonDocument()).ToList();

        }
    }
}
