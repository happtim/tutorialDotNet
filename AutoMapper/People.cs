using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectMapper
{

    public enum Sex {
        男 = 0,
        女
    }

    public class People {
        public string Name { get; set; }
        public int Age { get; set; }
        public string BirthDay { get; set; }
        public Sex Sex { get; set; }
        public string Leg { get; set; }
        public int LeftFinger {get;set;}
        public int RightFinger { get; set; }
    }

    public class PeopleEntity {
        public string name { get; set; }
        public int age { get; set; }
        public DateTime BirthDay { get; set; }
        public string Sex { get; set; }
        public int Leg { get; set; }
        public int TotalFinger { get; set; }
    }
}
