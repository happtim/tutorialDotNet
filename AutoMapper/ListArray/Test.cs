using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;

namespace ObjectMapper.ListArray
{
    [TestClass]
    public class Test {

        [TestMethod]
        public void TestListArray() {

            Mapper.Initialize(cfg => {
                cfg.CreateMap<People, PeopleEntity>();
            });

            IList<People> list = new List<People> {
                new People {Name = "Tim",Age = 19 },
                new People {Name ="Tom" ,Age = 20},
                new People {Name ="Sam" ,Age = 21},
            };

            var listEntities  = Mapper.Map<IList<People>, IList<PeopleEntity>>(list);

            Assert.AreEqual(listEntities[0].name, "Tim");
            Assert.AreEqual(listEntities[1].name, "Tom");
            Assert.AreEqual(listEntities[2].name, "Sam");

        }
    }
}
