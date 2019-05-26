namespace qlShop.qlshop_model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Required]
        [StringLength(100)]
        public string TenKhachHang { get; set; }

        [StringLength(20)]
        public string KhachHangID { get; set; }

        [StringLength(50)]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(500)]
        public string DiaChi { get; set; }

        public string GhiChu { get; set; }

        public DateTime? SinhNhat { get; set; }

        public bool? GioiTinh { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CongNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TongTienHang { get; set; }

        [Required]
        [StringLength(20)]
        public string NguoiDungID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNguoiDung { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
