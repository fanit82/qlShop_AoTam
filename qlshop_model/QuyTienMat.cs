namespace qlShop.qlshop_model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuyTienMat")]
    public partial class QuyTienMat
    {
        [Key]
        public int Key_ID { get; set; }

        public DateTime Ngay_ThaoTac { get; set; }

        [StringLength(50)]
        public string ChungTu_ID { get; set; }

        public DateTime? NgayChungTu { get; set; }

        [Column(TypeName = "money")]
        public decimal? TienDauKy { get; set; }

        [Column(TypeName = "money")]
        public decimal? TienNhap { get; set; }

        [Column(TypeName = "money")]
        public decimal? TienXuat { get; set; }

        [Column(TypeName = "money")]
        public decimal? TienCuoiKy { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        [StringLength(2)]
        public string PhanLoai { get; set; }
    }
}
