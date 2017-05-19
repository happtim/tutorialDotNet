using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityFramework.SampleOne
{

    [TestClass]
    public class Main
    {
        [TestMethod()]
        public void ConstructInject()
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IWaterTool, PressWater>();
            IPeople people = container.Resolve<VillagePeople>();
            people.DrinkWater();

        }

        [TestMethod()]
        public void PropertyInject() {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IWaterTool, CityWater>();
            IPeople people = container.Resolve<CityPeople>();
            people.DrinkWater();
        }

        [TestMethod()]
        public void methodInject() {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IWaterTool, SeaWater>();
            IPeople people = container.Resolve<ShipPeople>();
        }
    }
}
