using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;

namespace ObjectMapper.MemberConfigurationResolve
{

    [TestClass]
    public class Test {

        People people = new People { Name = "Tim", Age = 18, LeftFinger = 5, RightFinger = 5};

        public class CustomResolver : IValueResolver<People, PeopleEntity, int> {
            public int Resolve(People source, PeopleEntity destination, int finger, ResolutionContext context)
            {
               return source.LeftFinger * 4;
            }
        }

        [TestMethod]//目标值的一个转化
        public void TestCustomValueResolve() {

            Mapper.Initialize(cfg => {
                cfg.CreateMap<People, PeopleEntity>()
                    .ForMember(dest => dest.TotalFinger,
                        opt => opt.ResolveUsing((p, e) => p.RightFinger + p.LeftFinger))

                        //覆盖前面的了
                    .ForMember(dest => dest.TotalFinger, 
                        opt => opt.ResolveUsing<CustomResolver>() );
                    
                cfg.CreateMap<string, DateTime>().ConvertUsing(s => Convert.ToDateTime(s));
            });

            var entity = Mapper.Map<People, PeopleEntity>(people);

            Assert.AreEqual(entity.TotalFinger, 20);

        }
    }
}
