using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

namespace ObjectMapper.Profiles
{
    public class PeopleProfile : Profile {

        public PeopleProfile() {
            CreateMap<People, PeopleEntity>();
        }
    }
}
