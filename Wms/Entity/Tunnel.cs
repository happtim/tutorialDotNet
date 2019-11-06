namespace Wms.Entity
{ 
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tunnel : OperationRecord
    {
        //public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TunnelNo { get; set; }

        [Required]
        [StringLength(50)]
        public string TunnelName { get; set; }

        public int TunnelType { get; set; }

        public int TunnelSort { get; set; }

        public bool Status { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public long TunnelMaterialId { get; set; }
        public int TunnelMaterialType { get; set; }

        //外键 约定
        //public int AreaId { get; set; }    //主表主键
        //public int RegionAreaId {get;set;} //导航属性+主表主键
        public int AreaId { get; set; }  //主表+主表主键

        public virtual Area Region { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
