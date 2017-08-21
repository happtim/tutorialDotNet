using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;

namespace ObjectMapper.BeforeAfterAction
{
    [TestClass]
    public class Test {

        People people = new People { Name = "Tim", Age = 18 };

        [TestMethod]
        public void TestBeforeAfterAction() {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<People, PeopleEntity>()
                    .BeforeMap((src, dest) => src.Age = 19)
                    .AfterMap((src, dest) => src.Age = 20);
            });

            var entity = Mapper.Map<People, PeopleEntity>(people);

            Assert.AreEqual(people.Age, 20);
            Assert.AreEqual(entity.age, 19);

        }
    }
}
