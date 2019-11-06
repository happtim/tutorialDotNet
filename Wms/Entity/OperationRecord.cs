using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Entity
{
    public class OperationRecord
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(20)]
        public string CreatedBy { get; set; }

        [StringLength(20)]
        public string CreatedUser { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(20)]
        public string UpdatedBy { get; set; }

        [StringLength(20)]
        public string UpdatedUser { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}
