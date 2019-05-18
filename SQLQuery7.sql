Begin
	Declare @Thang int
	Declare @Nam int
	declare @DoanhThu money
	declare @ConNo money
	Declare @TienGiamGia money
	Declare @TienMuaHang money
	Declare @ChiPhi money
	set @Thang =8
	set @Nam =2015
	Select @DoanhThu = sum(TongCong), @TienGiamGia = sum(GiamGia),@ConNo =sum(ConNo)
	from DonHang where MONTH(NgayBan) = @Thang and YEAR(NgayBan) = @Nam	

	select @TienMuaHang =sum(TienHang) from PhieuNhap 
	where MONTH(NgayNhap) = @Thang and year(NgayNhap) = @Nam

	Select @ChiPhi=sum(SoTien)
	from ChiPhi
	Where MONTH(NgayChi) = @Thang and year(NgayChi) = @Nam
	Select @DoanhThu as DoanhThu,@TienGiamGia as TienGiamGia,@TienMuaHang as TienMuaHang,@ChiPhi as ChiPhi

end
