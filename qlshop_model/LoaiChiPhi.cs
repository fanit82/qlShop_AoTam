namespace qlShop.qlshop_model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiChiPhi")]
    public partial class LoaiChiPhi
    {
        public int LoaiChiPhiID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenLoaiChiPhi { get; set; }
    }
}
