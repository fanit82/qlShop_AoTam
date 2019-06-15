namespace qlShop.qlshop_model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhap")]
    public partial class PhieuNhap
    {
        [StringLength(20)]
        public string PhieuNhapID { get; set; }

        [StringLength(20)]
        public string NhaCungCapID { get; set; }

        [StringLength(50)]
        public string TenNhaCungCap { get; set; }

        [StringLength(50)]
        public string MaPhieuNCC { get; set; }

        public DateTime NgayNhap { get; set; }

        [Required]
        [StringLength(20)]
        public string NhanVienID { get; set; }

        [StringLength(50)]
        public string TenNhanVien { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TienHang { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ThanhToan { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ConNo { get; set; }

        public DateTime? LastUpdate { get; set; }
    }
}
