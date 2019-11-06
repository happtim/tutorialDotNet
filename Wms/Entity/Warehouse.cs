namespace Wms.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Warehouse")]
    public partial class Warehouse :OperationRecord
    {
        //创建约定
        // 1) 表进入数据都会复数形式
        // 2.1)会使用id作为主键 或  2.1)"实体ID"作为主键 如果主键是int或者guid则要设置
        // 3.1)外键 导航属性+主表主键 3.2)主表+主表主键 3.3)主表主键 3.4)如果没有设置 主表+_+主表主键
        // 4)所有引用类型字段可以为空,如int? , string , Area
        // 5.1)主键字段不可控 5.2)设置了[Require]属性字段不可空  5.3)值类型字段不可控
        // 6)列的顺序和entity属性字段顺序一致



        public bool Status { get; set; }

        [Required]
        [StringLength(20)]
        public string WarehouseNo { get; set; }


        [StringLength(50)]
        public string BarCode { get; set; }

        [Required]
        [StringLength(20)]
        public string WarehouseName { get; set; }

        public short WarehouseType { get; set; }


        [StringLength(50)]
        public string Address { get; set; }


        [StringLength(20)]
        public string ChargePerson { get; set; }


        [StringLength(20)]
        public string ChargePersonPhone { get; set; }

        [Required]
        [StringLength(20)]
        public string Capacity { get; set; }


        [StringLength(200)]
        public string Remark { get; set; }

        public virtual ICollection<Area> Areas { get; set; }


    }
}
