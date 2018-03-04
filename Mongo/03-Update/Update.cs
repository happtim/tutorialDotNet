using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongo._03_Update
{
    [TestClass]
    public class Update {

        [TestMethod]
        public void Test() {
            var client = new MongoClient("mongodb://localhost:27017");

            var database = client.GetDatabase("agv");

            var collection = database.GetCollection<BsonDocument>("car_station");

            var filter = Builders<BsonDocument>.Filter.Eq("i", 10);
            var update = Builders<BsonDocument>.Update.Set("i", 110);

            //更新一条数据
            collection.UpdateOne(filter, update);
            //更新很多数据
            collection.UpdateMany(filter, update);

        }
    }
}
