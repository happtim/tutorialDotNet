using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityFramework.SampleOne
{
    public class ShipPeople : IPeople
    {
        [Dependency]
        public IWaterTool pw { get; set; }

        [InjectionMethod]
        public void DrinkWater()
        {
            Console.WriteLine(pw.GetWater());
        }
    }
}
