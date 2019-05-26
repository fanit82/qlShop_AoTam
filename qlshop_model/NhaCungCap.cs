namespace qlShop.qlshop_model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaCungCap")]
    public partial class NhaCungCap
    {
        [Required]
        [StringLength(100)]
        public string TenNhaCungCap { get; set; }

        [StringLength(20)]
        public string NhaCungCapID { get; set; }

        [StringLength(50)]
        public string SoDienThoai { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string MST { get; set; }

        [StringLength(50)]
        public string NguoiLienHe { get; set; }

        public string GhiChu { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CongNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TongTienHang { get; set; }

        [Required]
        [StringLength(20)]
        public string NguoiDungID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNguoiDung { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
