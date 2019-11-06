namespace Wms.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LocationDetail")]
    public partial class LocationDetail : OperationRecord
    {
        //public int Id { get; set; }

        public long Quantity { get; set; }

        [StringLength(20)]
        public string Unit { get; set; }

        public decimal StandardQty { get; set; }

        [StringLength(50)]
        public string LotNumber { get; set; }

        public short OccupyType { get; set; }

        public int ContentQuantity { get; set; }
        [StringLength(50)]
        public string OrderSerialNo { get; set; }
        [StringLength(50)]
        public string Extend { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public int MaterialId { get; set; }

        public virtual Material Material { get; set; }
    }
}
