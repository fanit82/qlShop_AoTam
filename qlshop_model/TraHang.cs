namespace qlShop.qlshop_model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TraHang")]
    public partial class TraHang
    {
        [StringLength(20)]
        public string TraHangID { get; set; }

        [Required]
        [StringLength(20)]
        public string DonHangID { get; set; }

        [StringLength(20)]
        public string KhachHangID { get; set; }

        [StringLength(50)]
        public string TenKhachHang { get; set; }

        public DateTime NgayTra { get; set; }

        public DateTime NgayBan { get; set; }

        [Column(TypeName = "money")]
        public decimal? TongTienTra { get; set; }

        [StringLength(20)]
        public string NhanVienID { get; set; }

        [StringLength(50)]
        public string TenNhanVien { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        public DateTime? LastUpdate { get; set; }
    }
}
