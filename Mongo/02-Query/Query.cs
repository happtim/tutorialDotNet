using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Mongo._02_Query
{
    [TestClass]
    public class Query {

        [TestMethod]
        public void Test() {

            var client = new MongoClient("mongodb://localhost:27017");

            var database = client.GetDatabase("agv");

            var collection = database.GetCollection<BsonDocument>("car_station");

            //查询一条数据
            var document = collection.Find(new BsonDocument()).FirstOrDefault();

            //查询所有数据
            var documents = collection.Find(new BsonDocument()).ToList();

            //大量数据使用Enumerable
            var cursor = collection.Find(new BsonDocument()).ToCursor();
            foreach (var doc in cursor.ToEnumerable())
            {
                Console.WriteLine(document);
            }

            //通过filter获取一个文档
            var filter = Builders<BsonDocument>.Filter.Eq("counter", 71);

            //&操作
            var filterBuilder = Builders<BsonDocument>.Filter;
            filter = filterBuilder.Gt("counter", 50) & filterBuilder.Lte("counter", 100);

            document = collection.Find(filter).First();

            //字段 Project
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");
            document = collection.Find(new BsonDocument()).Project(projection).First();


        }
    }
}
