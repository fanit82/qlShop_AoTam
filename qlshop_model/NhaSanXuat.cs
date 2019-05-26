namespace qlShop.qlshop_model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaSanXuat")]
    public partial class NhaSanXuat
    {
        public int NhaSanXuatID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNhaSanXuat { get; set; }

        [Required]
        [StringLength(20)]
        public string NguoiDungID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNguoiDung { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
