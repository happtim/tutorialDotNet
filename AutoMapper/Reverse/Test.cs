using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;

namespace ObjectMapper.Reverse
{
    [TestClass]
    public class Test {

        [TestMethod]//映射反转
        public void TestReverse() {

            People tim = new People { Name = "Tim" };

            Mapper.Initialize(cfg => {
                cfg.CreateMap<People, PeopleEntity>().ReverseMap();
            });

            var timEntity = Mapper.Map<People, PeopleEntity>(tim);
            Assert.AreEqual(timEntity.name, "Tim");

            var timReverse = Mapper.Map<PeopleEntity, People>(timEntity);
            Assert.AreEqual(timReverse.Name, "Tim");


        }
    }
}
