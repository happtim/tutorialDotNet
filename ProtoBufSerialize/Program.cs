using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//using static ProtoBufSerialize.Old.Person.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Google.Protobuf;
using old =  ProtoBufSerialize.Old;
using news = ProtoBufSerialize.New;

namespace ProtoBufSerialize
{
    [TestClass]
    public class Program
    {
        static void Main(string[] args) { }

        [TestMethod]
        public void SerializeToOld() {

            old.Person john = new old.Person {
                Id = 1234,
                Name = "John Doe",
                Email = "jdoe@example.com",
                Phones = { new old.Person.Types.PhoneNumber { Number = "555-4321", Type = old.Person.Types.PhoneType.Home } }
            };

            //Old Serialize 
            using (var output = File.Create("john.dat")) {
                john.WriteTo(output);
            }
        }


        [TestMethod]
        public void SerializeToNew() {

            news.Person john = new news.Person {
                Id = 1234,
                Name = "John Doe",
                Email = "jdoe@example.com",
                Phones = { new news.Person.Types.PhoneNumber { Number = "555-4321", Type = news.Person.Types.PhoneType.Home } },
                Age = 123,
                Address = "青岛赛轮",
            };

            //Old Serialize 
            using (var output = File.Create("john.dat2")) {
                john.WriteTo(output);
            }
        }


        [TestMethod]
        public void DeSerializeOldToNew() {
            //New DeSerialize
            news.Person john;
            using (var input = File.OpenRead("john.dat")) {
                john = news.Person.Parser.ParseFrom(input);
            }
            Console.Write(john);
        }



        [TestMethod]
        public void DeSerializeNewToOld() {

            //New DeSerialize
            old.Person john;
            using (var input = File.OpenRead("john.dat2")) {
                john = old.Person.Parser.ParseFrom(input);
            }
            Console.Write(john);
        }

        [TestMethod]
        public void DeSerializeNewToNew() {
            //New DeSerialize
            news.Person john;
            using (var input = File.OpenRead("john.dat2")) {
                john = news.Person.Parser.ParseFrom(input);
            }
            Console.Write(john);
        }


    }
}
