namespace Wms
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Wms.Entity;
    using System.IO;

    public class WmsContext : DbContext
    {
        //ʹ���������ݿ��ַ�����ʽ
        public WmsContext()  : base("name=Wms")
        {
            //���ݿ�ĳ�ʼ����ʽ
            //�������ݿ����û�еĻ�
            //Database.SetInitializer<WmsContext>(new CreateDatabaseIfNotExists<WmsContext>());
            //���ʵ�巢���ı������´������ݿ�
            //Database.SetInitializer<WmsContext>(new DropCreateDatabaseIfModelChanges<WmsContext>());
            //ÿ��������ɾ�����ݿ�
            //Database.SetInitializer<WmsContext>(new DropCreateDatabaseAlways<WmsContext>());

            //ʹ��ÿ��ɾ�����ݿⷽʽ,�����������ݿ��ʼ������
            Database.SetInitializer<WmsContext>(new WmsDbInitializer());
            Database.Log = (message) => {
                var file = new StreamWriter("./log",true);
                file.WriteLine(message);
                file.Close();
            };

        }
        
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Tunnel> Tunnels { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationDetail> LocationDetails { get; set; }
        public virtual DbSet<Material> Materials { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>()
                .Map(m =>
            {
                m.MapInheritedProperties();
            });

            modelBuilder.Entity<Area>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Area");
            });

            modelBuilder.Entity<Area>()
                .HasMany<Tunnel>(a => a.Tunnels)
                .WithRequired(t => t.Region)
                .HasForeignKey<int>(t => t.AreaId);

            modelBuilder.Entity<Area>()
                .HasRequired<Warehouse>(a => a.Warehouse)
                .WithMany(w => w.Areas)
                .HasForeignKey(a => a.WarehouseId);


        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is OperationRecord && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                entity.State = ((OperationRecord)(entity.Entity)).Id == 0 ? EntityState.Added : EntityState.Modified;

                if (entity.State == EntityState.Added)
                {
                    ((OperationRecord)(entity.Entity)).CreatedDate = DateTime.Now;
                }

               ((OperationRecord)(entity.Entity)).UpdatedDate = DateTime.Now;

            }

            return base.SaveChanges();
        }

    }

}