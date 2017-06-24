using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization.Formatters.Binary;

namespace Base.Serialize
{

    [TestClass]
    public class ListSerialize
    {
        //序列化为值类型
        [TestMethod]
        public void testSerializeValue() {

            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            FileStream fs = new FileStream("list", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, list);
            fs.Close();
        }

        //反序列化值类型
        [TestMethod]
        public void testDeSerializeValue() {

            FileStream fs = new FileStream("list", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            List<int> list =(List<int>) bf.Deserialize(fs);
            fs.Close();

            Assert.AreEqual(list[0], 1);
            Assert.AreEqual(list[1], 2);
            Assert.AreEqual(list[4], 5);
        }

        [Serializable]
        class Cat {
            public string name;
        }
        //序列化Object
        [TestMethod]
        public void testSerializeObject()
        {

            List<Cat> list = new List<Cat>() {
                new Cat() {name = "Tom" },
                new Cat() {name = "BlueCat" },
                new Cat() {name = "BlackCatPolice" }
            };
            FileStream fs = new FileStream("list_object", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, list);
            fs.Close();
        }

        //反序列化值类型
        [TestMethod]
        public void testDeSerializeObject()
        {

            FileStream fs = new FileStream("list_object", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            List<Cat> list = (List<Cat>)bf.Deserialize(fs);
            fs.Close();

            Assert.AreEqual(list[0].name, "Tom");
            Assert.AreEqual(list[1].name, "BlueCat");
            Assert.AreEqual(list[2].name, "BlackCatPolice");
        }

        [Serializable]
        class CatHome {
            private List<Cat> list = new List<Cat>();
            //public CatHome(List<Cat> list) {
            //    this.list = list;
            //}

            public void Initialize(List<Cat> list) {
                this.list = list;
            }

            public List<Cat> List{
                get {
                    return this.list;
                }
            }
        }

        //序列化带list的对象
        [TestMethod]
        public void testSerializeObjectWithList()
        {

            List<Cat> list = new List<Cat>() {
                new Cat() {name = "Tom" },
                new Cat() {name = "BlueCat" },
                new Cat() {name = "BlackCatPolice" }
            };
            CatHome home = new CatHome();
            home.Initialize(list);

            FileStream fs = new FileStream("object_with_list", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, home);
            fs.Close();
        }

        //反序列化值类型
        [TestMethod]
        public void testDeSerializeObjectWithList()
        {

            FileStream fs = new FileStream("object_with_list", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            CatHome home = (CatHome)bf.Deserialize(fs);
            fs.Close();

            Assert.AreEqual(home.List[0].name, "Tom");
            Assert.AreEqual(home.List[1].name, "BlueCat");
            Assert.AreEqual(home.List[2].name, "BlackCatPolice");
        }


    }
}
