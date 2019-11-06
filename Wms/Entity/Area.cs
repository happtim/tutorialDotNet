namespace Wms.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Area : OperationRecord
    {
        //[DatabaseGenerated( DatabaseGeneratedOption.Identity)]
        //public int AreaId { get; set; }

        [Required]
        [StringLength(50)]
        public string AreaNo { get; set; }

        [Required]
        [StringLength(50)]
        public string AreaName { get; set; }

        public int AreaType { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public bool Status { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public int RowCount { get; set; }
        public int LineCount { get; set; }
        public int LocationRule { get; set; }
        public int PickDirection { get; set; }

        public int WarehouseId { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        public virtual ICollection<Tunnel> Tunnels { get; set; } 
    }
}
