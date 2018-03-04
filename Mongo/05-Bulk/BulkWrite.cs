using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongo._05_Bulk
{
    [TestClass]
    public class BulkWrite {

        [TestMethod]
        public void Test() {

            var client = new MongoClient("mongodb://localhost:27017");

            var database = client.GetDatabase("agv");

            var collection = database.GetCollection<BsonDocument>("car_station");

            var models = new WriteModel<BsonDocument>[]
            {
                new InsertOneModel<BsonDocument>(new BsonDocument("_id", 4)),
                new InsertOneModel<BsonDocument>(new BsonDocument("_id", 5)),
                new InsertOneModel<BsonDocument>(new BsonDocument("_id", 6)),
                new UpdateOneModel<BsonDocument>(
                    new BsonDocument("_id", 1),
                    new BsonDocument("$set", new BsonDocument("x", 2))),
                new DeleteOneModel<BsonDocument>(new BsonDocument("_id", 3)),
                new ReplaceOneModel<BsonDocument>(
                    new BsonDocument("_id", 3),
                    new BsonDocument("_id", 3).Add("x", 4))
            };

            // 1. Ordered bulk operation - order of operation is guaranteed
            collection.BulkWrite(models);

            // 2. Unordered bulk operation - no guarantee of order of operation
            collection.BulkWrite(models, new BulkWriteOptions { IsOrdered = false });

        }
    }
}
