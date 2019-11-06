namespace Wms.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Material : OperationRecord
    {
        //public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string PartCode { get; set; }

        [Required]
        [StringLength(50)]
        public string PartName { get; set; }

        public decimal Price { get; set; }


        [StringLength(100)]
        public string Unit { get; set; }

        public DateTime? ProductionDateStart { get; set; }

        public DateTime? ProductionDateEnd { get; set; }

        public int MaterialType { get; set; }

        /// <summary>
        /// 父级id
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; set; }

        public int DefaultQuantity { get; set; }

        public bool Status { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public string Extend { get; set; }
    }
}
