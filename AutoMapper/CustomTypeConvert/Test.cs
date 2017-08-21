using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;

namespace ObjectMapper.CustomTypeConvert
{
    [TestClass]
    public class Test {
        People people = new People { Name = "Tim", Age = 18, BirthDay = "01/01/2001", Sex = Sex.女, Leg = "2" };
        [TestMethod]
        public void TestCustomTypeConvert() {

            Mapper.Initialize(cfg => {
                cfg.CreateMap<People, PeopleEntity>();
                cfg.CreateMap<string, DateTime>().ConvertUsing(s => Convert.ToDateTime(s));
            });

            Mapper.Configuration.AssertConfigurationIsValid();

            var entity = Mapper.Map<People, PeopleEntity>(people);

            Assert.AreEqual(entity.BirthDay, DateTime.Parse("01/01/2001"));
            Assert.AreEqual(entity.Sex, "女");
            Assert.AreEqual(entity.Leg, 2);
            
        }
    }
}
