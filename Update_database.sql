use qlShop2
Create proc NH_KhachHang_SinhNhat
as
Select *
from KhachHang
where MONTH(SinhNhat) = MONTH(GETDATE())
and DAY(SinhNhat) = DAY(GETDATE())
go

/**
1.doanh so ban hang
2.Tong cong no trong thang
3.so tien gach no
4.so tien thu truc tiep (ban han thu tien) 
5.so tien chi trong thang
6.so tien nhap hang trong than
7.
*/
Create proc NH_BaoCaoTongHop
(
@THANG_LV AS INT,
@NAM_LV AS INT
)
as

BEGIN
/*
DECLARE @THANG_LV AS INT
DECLARE @NAM_LV AS INT
SET @THANG_LV =6
SET @NAM_LV = 2015
*/
SELECT N'Doanh số bán hàng' as TieuDe, isnull(SUM(TongCong),0) AS SOTIEN FROM DonHang WHERE MONTH(NgayBan)*12 + YEAR(NgayBan) = @THANG_LV*12 + @NAM_LV
UNION ALL
SELECT N'Khách nợ trong tháng' as TieuDe, isnull(SUM(ConNo),0) FROM DonHang WHERE MONTH(NgayBan)*12 + YEAR(NgayBan) = @THANG_LV*12 + @NAM_LV
union all
SELECT N'Thanh toán tiền mặt' as TieuDe, isnull(SUM(ThanhToan),0) FROM DonHang WHERE MONTH(NgayBan)*12 + YEAR(NgayBan) = @THANG_LV*12 + @NAM_LV
UNION ALL
SELECT N'Tiền Thu nợ', isnull(SUM(TienThu),0) FROM PhieuGachNo WHERE MONTH(NgayGachNo)*12 + YEAR(NgayGachNo) = @THANG_LV*12 + @NAM_LV
UNION ALL
SELECT N'Tiền chi trong tháng', isnull(SUM(SoTien),0) FROM ChiPhi  WHERE MONTH(NgayChi)*12 + YEAR(NgayChi) = @THANG_LV*12 + @NAM_LV
UNION ALL
SELECT N'Tiền nhập hàng trong tháng', isnull(SUM(TienHang),0) FROM PhieuNhap WHERE MONTH(NgayNhap)*12 + YEAR(NgayNhap) = @THANG_LV*12 + @NAM_LV
END
