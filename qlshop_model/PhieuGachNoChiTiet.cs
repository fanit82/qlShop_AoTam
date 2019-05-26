namespace qlShop.qlshop_model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuGachNoChiTiet")]
    public partial class PhieuGachNoChiTiet
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string PhieuGachNoID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string DonHangID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TienNo { get; set; }
    }
}
