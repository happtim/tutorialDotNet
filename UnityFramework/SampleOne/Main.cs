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

        //实例注入
        [TestMethod()]
        public void InstanceInject()
        {
            UnityContainer container = new UnityContainer();
            IWaterTool tool = new CityWater();
            container.RegisterInstance<IWaterTool>(tool);
            IWaterTool tool2 = container.Resolve<IWaterTool>();

            Assert.AreEqual(tool, tool2);
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

        //有一些业务模块时横切整个项目的，比如log，cache，exception，Authentication and authorization
        //将这些横切模块翻入代码逻辑中的一种普遍方法是时用装饰模式
        [TestMethod()]
        public void interception() {
            UnityContainer container = new UnityContainer();

            container.RegisterType<IWaterTool, PressWater>();
            container.RegisterType<ILogger, ConsoleLogger>();

//            container.RegisterType<IPeople, ShipPeople>("ShipPeople");
            container.RegisterType<IPeople, VillagePeople>("VillagePeople");


            container.RegisterType<IPeople, LoggerPeople>(new InjectionConstructor(
                new ResolvedParameter<IPeople>("VillagePeople"),
                new ResolvedParameter<ILogger>()
                ));

            IPeople people = container.Resolve<IPeople>();
            people.DrinkWater();
        }


    }
}
