using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityFramework.SampleOne
{
    public class VillagePeople : IPeople
    {
        private IWaterTool pw;

        public VillagePeople(IWaterTool pw) {
            this.pw = pw;
        }

        public void DrinkWater() {
            Console.WriteLine(pw.GetWater());
        }
    }
}
