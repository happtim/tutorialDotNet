using System;
using System.Collections.Generic;
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
                
                var location =  locations.First(l => l.LocationNo == "location001");

                context.LocationDetails.Add(new LocationDetail { Location = location,Material = materials.First() });

                context.SaveChanges();
            }
        }
    }
}
