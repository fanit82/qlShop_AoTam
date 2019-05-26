namespace qlShop.qlshop_model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QlShop : DbContext
    {
        public QlShop()
            : base("name=QlShop_cnn")
        {
        }

        public virtual DbSet<ChiPhi> ChiPhis { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiChiPhi> LoaiChiPhis { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhaSanXuat> NhaSanXuats { get; set; }
        public virtual DbSet<NhomHang> NhomHangs { get; set; }
        public virtual DbSet<PhieuGachNo> PhieuGachNoes { get; set; }
        public virtual DbSet<PhieuGachNoChiTiet> PhieuGachNoChiTiets { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<PhieuNhapChiTiet> PhieuNhapChiTiets { get; set; }
        public virtual DbSet<QuyTienMat> QuyTienMats { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<ThongTinShop> ThongTinShops { get; set; }
        public virtual DbSet<TraHang> TraHangs { get; set; }
        public virtual DbSet<TraHangChiTiet> TraHangChiTiets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiPhi>()
                .Property(e => e.SoTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.TienHang)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.GiamGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.TongCong)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.ThanhToan)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.ConNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.KhachDua)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.TienThua)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonHangChiTiet>()
                .Property(e => e.DonGia)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DonHangChiTiet>()
                .Property(e => e.GiaVon)
                .HasPrecision(9, 0);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.CongNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.TongTienHang)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.CongNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.TongTienHang)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhieuGachNo>()
                .Property(e => e.TienThu)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhieuGachNo>()
                .Property(e => e.TienNoHienTai)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhieuGachNoChiTiet>()
                .Property(e => e.TienNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhieuNhap>()
                .Property(e => e.TienHang)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhieuNhap>()
                .Property(e => e.ThanhToan)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhieuNhap>()
                .Property(e => e.ConNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhieuNhapChiTiet>()
                .Property(e => e.DonGia)
                .HasPrecision(9, 0);

            modelBuilder.Entity<QuyTienMat>()
                .Property(e => e.TienDauKy)
                .HasPrecision(19, 4);

            modelBuilder.Entity<QuyTienMat>()
                .Property(e => e.TienNhap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<QuyTienMat>()
                .Property(e => e.TienXuat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<QuyTienMat>()
                .Property(e => e.TienCuoiKy)
                .HasPrecision(19, 4);

            modelBuilder.Entity<QuyTienMat>()
                .Property(e => e.PhanLoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TraHang>()
                .Property(e => e.TongTienTra)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TraHangChiTiet>()
                .Property(e => e.DonGiaTra)
                .HasPrecision(9, 0);

            modelBuilder.Entity<TraHangChiTiet>()
                .Property(e => e.DonGia)
                .HasPrecision(9, 0);

            modelBuilder.Entity<TraHangChiTiet>()
                .Property(e => e.GiaVon)
                .HasPrecision(9, 0);
        }
    }
}
