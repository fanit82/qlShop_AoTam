namespace qlShop.qlshop_model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuGachNo")]
    public partial class PhieuGachNo
    {
        [StringLength(20)]
        public string PhieuGachNoID { get; set; }

        public DateTime NgayGachNo { get; set; }

        [Required]
        [StringLength(20)]
        public string KhachHangID { get; set; }

        [StringLength(50)]
        public string TenKhachHang { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TienThu { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TienNoHienTai { get; set; }

        [StringLength(20)]
        public string NguoiDungID { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastUpdate { get; set; }
    }
}
