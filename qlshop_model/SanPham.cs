namespace qlShop.qlshop_model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [StringLength(20)]
        public string SanPhamID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSanPham { get; set; }

        [StringLength(20)]
        public string EXT_ID { get; set; }

        [StringLength(20)]
        public string DVT { get; set; }

        [StringLength(20)]
        public string GioTinh { get; set; }

        [StringLength(10)]
        public string NhomSize { get; set; }

        public int? NhomHangID { get; set; }

        [StringLength(50)]
        public string TenNhomHang { get; set; }

        public int? GiaVon { get; set; }

        public int? GiaBan { get; set; }

        public int? SLTonKho { get; set; }

        public int? ThuaVAT { get; set; }

        [Column(TypeName = "image")]
        public byte[] HinhAnh { get; set; }

        public int? NhaSanXuatID { get; set; }

        [StringLength(50)]
        public string TenNhaSanXuat { get; set; }

        public bool? NgungKinhDoanh { get; set; }

        public bool? ChoXuatAm { get; set; }

        [StringLength(20)]
        public string NguoiDungID { get; set; }

        [StringLength(50)]
        public string TenNguoiDung { get; set; }

        public DateTime? LastUpdate { get; set; }

        public int? TonKhoiTao { get; set; }

        public DateTime? NgayKhoiTao { get; set; }
    }
}
