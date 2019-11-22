using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wms.Entity;

namespace Wms
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Warehouse> warehousesWithEagerLoading = null;
            List<Material> materials = null;


            using (var context = new WmsContext()) {

                materials = context.Materials.ToList();

                var warehousesWithLazyLoading = context.Warehouses.ToList();

                warehousesWithEagerLoading = context.Warehouses.Include("Areas.Tunnels.Locations.LocationDetails.Material").ToList();

                foreach (Warehouse warehouse in warehousesWithLazyLoading) {
                    Console.WriteLine(warehouse.WarehouseNo);
                }
            }

            var areas = warehousesWithEagerLoading.SelectMany(w => w.Areas);
            var tunnels = areas.SelectMany(a => a.Tunnels);
            var locations = tunnels.SelectMany(t => t.Locations);

            using (var context = new WmsContext()) {

                var area2 =  areas.First(a => a.AreaName == "母胶库002");

                var warehouse1 = warehousesWithEagerLoading.FirstOrDefault(w => w.WarehouseNo == "lianjiao001");

                // 显式的指定外键的更新方法
                context.Areas.Attach(area2);
                area2.WarehouseId = warehouse1.Id;


                // ef自己加外键(隐式)的方式 更新导航属性太麻烦了.
                //context.Areas.Attach(area2);
                //context.Warehouses.Attach(warehouse1);

                //((IObjectContextAdapter)context).ObjectContext.
                //    ObjectStateManager.
                //    ChangeRelationshipState(area2, area2.Warehouse, a => a.Warehouse, System.Data.Entity.EntityState.Deleted);

                //((IObjectContextAdapter)context).ObjectContext.
                //  ObjectStateManager.
                //  ChangeRelationshipState(area2, warehouse1, a => a.Warehouse, System.Data.Entity.EntityState.Added);


                var location =  locations.First(l => l.LocationNo == "location001");

                context.LocationDetails.Add(new LocationDetail { Location = location,Material = materials.First() });

                context.SaveChanges();
            }
        }
    }
}
