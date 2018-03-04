using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Mongo._04_Delete
{
    [TestClass]
    public class Delete {

        [TestMethod]
        public void Test() {
            var client = new MongoClient("mongodb://localhost:27017");

            var database = client.GetDatabase("agv");

            var collection = database.GetCollection<BsonDocument>("car_station");

            var filter = Builders<BsonDocument>.Filter.Eq("i", 10);

            collection.DeleteOne(filter);
        }
    }
}
