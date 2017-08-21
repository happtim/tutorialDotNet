using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;

namespace ObjectMapper.MemberConfigurationMapFrom
{
    [TestClass]
    public class Test {

        [TestMethod]//source => dest 映射. ResolveUsing 比他多了一个目标类型
        public void TestMapFrom() {

            People tim = new People() { Name = "Tim", Age = 19 };

            Mapper.Initialize(cfg => {
                cfg.CreateMap<People, PeopleEntity>()
                    //.ForMember(dest => dest.name, opt => opt.MapFrom(p => p.Name + p.Age))

                    .ForMember(dest => dest.name, opt => opt.ResolveUsing((p,e) => {
                        return p.Name + p.Age; } ) );
                  ;
            });

            var timEntity = Mapper.Map<People, PeopleEntity>(tim);
            Assert.AreEqual(timEntity.name, "Tim19");


        }
    }
}
