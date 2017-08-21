using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;

using ObjectMapper.Profiles;

namespace ObjectMapper.Configuration
{

    [TestClass]
    public class Test {

        People people = new People { Name = "Tim", Age = 18 };

        [TestMethod]//配置文件配置
        public void TestMapperConfiguration() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<People, PeopleEntity>();
                //使用Profile是一个更高组织方式
                cfg.AddProfile<PeopleProfile>();
            });
        }

        [TestMethod]//Mapper实体配置
        public void TestStaticMapperInstance() {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<People, PeopleEntity>();
                cfg.AddProfile<PeopleProfile>();
            });
        }

        [TestMethod]//通过程序集扫描方式将所有继承自Profile中的类加载进来
        public void TestAutoScanning() {

            Assembly myassembly = Assembly.GetAssembly( typeof(Test) );

            Mapper.Initialize(cfg => {
                cfg.AddProfiles(myassembly);
            });

            var entity = Mapper.Map<People, PeopleEntity>(people);

            Assert.AreEqual(entity.age, 18);
        }


        [TestMethod]//property_name -> PropertyName
        public void TestNamingConvention() {
            Mapper.Initialize(cfg => {
                cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
                cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            });
        }
    }
}
