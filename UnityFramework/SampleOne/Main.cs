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
        //构造器注入
        [TestMethod()]
        public void ConstructInject()
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IWaterTool, PressWater>();
            IPeople people = container.Resolve<VillagePeople>();
            people.DrinkWater();

        }

        //属性注入
        [TestMethod()]
        public void PropertyInject() {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IWaterTool, CityWater>();
            IPeople people = container.Resolve<CityPeople>();
            people.DrinkWater();
        }

        //方法注入
        [TestMethod()]
        public void methodInject() {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IWaterTool, SeaWater>();
            IPeople people = container.Resolve<ShipPeople>();
        }

        //上面方法都使用接口作为对象标识符
        //当有多个接口注册时就是不知道用哪个了，所以使用标志符标识
        [TestMethod()]
        public void Identify() {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IWaterTool, CityWater>("CityWatter");
            container.RegisterType<IWaterTool, PressWater>("PressWater");

            IWaterTool cityWater = container.Resolve<IWaterTool>("CityWatter");
            Console.WriteLine(cityWater.GetWater());

            var list = container.ResolveAll<IWaterTool>();
        }

        //Resolve使用暂时的生命周期，如果想生成持久的使用ContainerControlledLifetimeManager
        [TestMethod()]
        public void lifetime() {

            UnityContainer container = new UnityContainer();
            container.RegisterType<IWaterTool, SeaWater>("SeaWater",new TransientLifetimeManager());

            IWaterTool left  = container.Resolve<IWaterTool>("SeaWater");
            IWaterTool right = container.Resolve<IWaterTool>("SeaWater");

            Assert.AreNotEqual(left, right);

            container.RegisterType<IWaterTool, PressWater>("PressWater", new ContainerControlledLifetimeManager());
            left = container.Resolve<IWaterTool>("PressWater");
            right = container.Resolve<IWaterTool>("PressWater");

            Assert.AreEqual(left, right);

        }


    }
}
