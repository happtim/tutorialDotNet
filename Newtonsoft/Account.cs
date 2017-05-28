using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
namespace Newtonsoft
{
    class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }

        [OnDeserialized]
        internal void OnSerializedMethod(StreamingContext context)
        {
            Email = "123";
        }

        [OnSerializing]
        internal void OnSerializingMethod(StreamingContext context)
        {
            Email = "This value went into the data file during serialization.";
        }

    }
}
