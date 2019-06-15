namespace qlShop.qlshop_model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhapChiTiet")]
    public partial class PhieuNhapChiTiet
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string PhieuNhapID { get; set; }

        [Required]
        [StringLength(20)]
        public string SanPhamID { get; set; }

        [StringLength(50)]
        public string TenSanPham { get; set; }

        [Required]
        [StringLength(5)]
        public string Size { get; set; }

        public int? SoLuong { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DonGia { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
