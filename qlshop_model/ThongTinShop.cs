namespace qlShop.qlshop_model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinShop")]
    public partial class ThongTinShop
    {
        [Key]
        public int ShopID { get; set; }

        [StringLength(100)]
        public string TenShop { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        public string website { get; set; }
    }
}
