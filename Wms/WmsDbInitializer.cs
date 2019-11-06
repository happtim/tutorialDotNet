using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wms.Entity;

namespace Wms
{
    public class WmsDbInitializer: DropCreateDatabaseAlways<WmsContext>
    {

        protected override void Seed(WmsContext context)
        {
            Warehouse warehouse1 = new Warehouse { Address = "贵州轮胎", Capacity = "100" , WarehouseName ="炼胶", WarehouseNo ="lianjiao001"};
            Warehouse warehouse2 = new Warehouse { Address = "贵州轮胎", Capacity = "100", WarehouseName = "炼胶2", WarehouseNo = "lianjiao002" };


            Area area1 = new Area { AreaName = "母胶库001", AreaNo = "mujiaoku001" };
            Area area2 = new Area { AreaName = "母胶库002", AreaNo = "mujiaoku002" };

            Tunnel tunnel1 = new Tunnel { TunnelName = "巷道001",TunnelNo = "xiangdao001" };
            Tunnel tunnel2 = new Tunnel { TunnelName = "巷道002", TunnelNo = "xiangdao002" };
            Tunnel tunnel3 = new Tunnel { TunnelName = "巷道003", TunnelNo = "xiangdao003" };
            Tunnel tunnel4 = new Tunnel { TunnelName = "巷道004", TunnelNo = "xiangdao004" };

            Location location1 = new Location { LocationNo = "location001" ,LocationName = "库位点001", Capacity = "100" , Load = "100" , InStorePoint = "0001", OuterStorePoint = "0002"};
            Location location2 = new Location { LocationNo = "location002", LocationName = "库位点002", Capacity = "100" , Load = "100" , InStorePoint = "0001", OuterStorePoint = "0002" };
            Location location3 = new Location { LocationNo = "location003", LocationName = "库位点003", Capacity = "100" , Load = "100" , InStorePoint = "0001", OuterStorePoint = "0002" };
            Location location4 = new Location { LocationNo = "location004", LocationName = "库位点004", Capacity = "100" , Load = "100" , InStorePoint = "0001", OuterStorePoint = "0002" };


            Material material1 = new Material { PartCode = "material001", PartName = "物料001" };
            Material material2 = new Material { PartCode = "material002", PartName = "物料002" };
            Material material3 = new Material { PartCode = "material003", PartName = "物料003" };
            Material material4 = new Material { PartCode = "material004", PartName = "物料004" };


            area1.Warehouse = warehouse1;
            area2.Warehouse = warehouse2;

            tunnel1.Region = area1;
            tunnel2.Region = area1;
            tunnel3.Region = area2;
            tunnel4.Region = area2;

            location1.Tunnel = tunnel1;
            location2.Tunnel = tunnel2;
            location3.Tunnel = tunnel3;
            location4.Tunnel = tunnel4;


            //context.Warehouses.Add(warehouse1);
            //context.Warehouses.Add(warehouse2);

            //context.Areas.Add(area1);
            //context.Areas.Add(area2);

            //context.Tunnels.AddRange(new Tunnel[] { tunnel1, tunnel2, tunnel3, tunnel4 });

            context.Locations.AddRange( new Location[] { location1,location2,location3,location4 });
            context.Materials.AddRange(new Material[] { material1, material2, material3, material4 });


            context.SaveChanges();

        }
    }
}
