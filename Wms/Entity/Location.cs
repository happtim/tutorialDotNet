namespace Wms.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Location")]
    public partial class Location : OperationRecord
    {
        //public int Id { get; set; }

        public bool Status { get; set; }

        [Required]
        [StringLength(20)]
        public string LocationNo { get; set; }

        [StringLength(20)]
        public string BarCode { get; set; }

        [Required]
        [StringLength(20)]
        public string LocationName { get; set; }

        public short LocationType { get; set; }


        [StringLength(50)]
        public string Address { get; set; }

        public short IsFrozen { get; set; }

        [Required]
        [StringLength(20)]
        public string Load { get; set; }

        [Required]
        [StringLength(20)]
        public string Capacity { get; set; }

        public short IsMixed { get; set; }


        public int LocationSort { get; set; }

        [Required]
        [StringLength(50)]
        public string InStorePoint { get; set; }

        [Required]
        [StringLength(50)]
        public string OuterStorePoint { get; set; }

        public long InstorePriority { get; set; }

        public long OutstorePriority { get; set; }

        public short MaterialType { get; set; }

        public string TaskTypeDesc { get; set; }
        public int Minutes { get; set; }

        public string Extend { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public int TunnelId { get; set; }

        public virtual Tunnel Tunnel { get; set; }

        public virtual ICollection<LocationDetail> LocationDetails { get; set; }

        public virtual ICollection<LocationDetail> EmptyLocatoinDetilas { get; set; }

    }
}
