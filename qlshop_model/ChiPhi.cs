namespace qlShop.qlshop_model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiPhi")]
    public partial class ChiPhi
    {
        public int ChiPhiID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenChiPhi { get; set; }

        public int LoaiChiPhiID { get; set; }

        [StringLength(50)]
        public string TenLoaiChiPhi { get; set; }

        public DateTime NgayChi { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SoTien { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        [Required]
        [StringLength(20)]
        public string NguoiDungID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNguoiDung { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
