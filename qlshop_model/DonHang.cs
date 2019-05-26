namespace qlShop.qlshop_model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [StringLength(20)]
        public string DonHangID { get; set; }

        [StringLength(20)]
        public string KhachHangID { get; set; }

        [StringLength(50)]
        public string TenKhachHang { get; set; }

        public DateTime NgayBan { get; set; }

        [StringLength(20)]
        public string NhanVienID { get; set; }

        [StringLength(50)]
        public string TenNhanVien { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TienHang { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GiamGia { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TongCong { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ThanhToan { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ConNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? KhachDua { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TienThua { get; set; }

        public DateTime? LastUpdate { get; set; }
    }
}
