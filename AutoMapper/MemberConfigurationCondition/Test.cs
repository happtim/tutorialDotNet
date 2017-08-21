using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;

namespace ObjectMapper.MemberConfigurationCondition
{
    [TestClass]
    public class Test {

        [TestMethod]//条件转化
        public void TestCondition() {

            People tim = new People { Name = "tim" };
            People timge = new People { Name = "timge" };

            Mapper.Initialize(cfg => {
                cfg.CreateMap<People, PeopleEntity>()
                    .ForMember(dest => dest.name , opt => opt.Condition(p => p.Name.Length > 4));
            });

            var timEntity = Mapper.Map<People, PeopleEntity>(tim);
            var timGeEntity = Mapper.Map<People, PeopleEntity>(timge);

            Assert.AreEqual(timEntity.name, null);
            Assert.AreEqual(timGeEntity.name, "timge");

        }

    }
}
