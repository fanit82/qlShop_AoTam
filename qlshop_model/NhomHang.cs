namespace qlShop.qlshop_model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomHang")]
    public partial class NhomHang
    {
        public int NhomHangID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNhomHang { get; set; }

        public int? NhomHangChaID { get; set; }

        [StringLength(500)]
        public string FullPath { get; set; }

        [Required]
        [StringLength(20)]
        public string NguoiDungID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNguoiDung { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
