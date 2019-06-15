namespace qlShop.qlshop_model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TraHangChiTiet")]
    public partial class TraHangChiTiet
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string TraHangID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string SanPhamID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSanPham { get; set; }

        [StringLength(5)]
        public string Size { get; set; }

        public int SoLuongBan { get; set; }

        public int SoLuongTra { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DonGiaTra { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DonGia { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GiaVon { get; set; }

        public int? TonKho { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
