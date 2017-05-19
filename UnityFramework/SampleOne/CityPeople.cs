using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityFramework.SampleOne
{
    public class CityPeople : IPeople
    {
        [Dependency]
        public IWaterTool pw { get; set; }

        public void DrinkWater()
        {
            Console.WriteLine(pw.GetWater());
        }
    }
}
