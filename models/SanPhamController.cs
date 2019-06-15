using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using qlShop.qlshop_model;

namespace qlShop.models
{
    static class SanPhamController
    {
        static QlShop dbControl = null;
        static public void Add(SanPham item)
        {
            dbControl = new QlShop();
            // nhung truong có gia trị mac định

            if (item.NgayKhoiTao is null) item.NgayKhoiTao = DateTime.Now;
            if (item.NgungKinhDoanh is null) item.NgungKinhDoanh = false;
            if (item.ChoXuatAm is null) item.ChoXuatAm = true;
            if (item.TonKhoiTao is null) item.TonKhoiTao = 0;
            if (item.SLTonKho is null) item.SLTonKho = 0;
            if (item.ThuaVAT is null) item.ThuaVAT = 0;
            if (item.GiaVon is null) item.GiaVon = 0;
            if (item.GiaBan is null) item.GiaBan = 0;

            //----------------------------------------------------------------------------
            //item.TonKhoiTao = item.SLTonKho;
            //item.NgayKhoiTao = DateTime.Now;
            dbControl.SanPhams.Add(item);
            dbControl.SaveChanges();
        }
        static public void Del(string strSanPhamID)
        {
            dbControl = new QlShop();
            SanPham DelItem = dbControl.SanPhams.SingleOrDefault(p => p.SanPhamID == strSanPhamID);
            if (DelItem!=null)
            {
                dbControl.SanPhams.Remove(DelItem);
                dbControl.SaveChanges();
            }
        }
        static public void Edit(SanPham item)
        {
            dbControl = new QlShop();
            SanPham oItem = new SanPham();
            oItem = dbControl.SanPhams.SingleOrDefault(p => p.SanPhamID == item.SanPhamID);
            if (oItem!=null)
            {
                oItem.TenSanPham = item.TenSanPham;
                oItem.NgungKinhDoanh = item.NgungKinhDoanh;
                oItem.ChoXuatAm = item.ChoXuatAm;
                oItem.GiaBan = item.GiaBan;
                oItem.GiaVon = item.GiaVon;
                oItem.NhaSanXuatID = item.NhaSanXuatID;
                oItem.TenNhaSanXuat = item.TenNhaSanXuat;
                oItem.NhomHangID = item.NhomHangID;
                oItem.TenNhomHang = item.TenNhomHang;
                oItem.ThuaVAT = item.ThuaVAT;
                oItem.HinhAnh = item.HinhAnh;
                //--thông tin bao mật
                oItem.NguoiDungID = Utility.NguoiSuDung.NguoiDungID;
                oItem.TenNguoiDung = Utility.NguoiSuDung.TenNguoiDung;
                oItem.LastUpdate = DateTime.Now;
                dbControl.SaveChanges();
            }
            dbControl.Dispose();
        }

        static public int GetTonKho(string strSanPhamID)
        {
            dbControl = new QlShop();
        SanPham Item = dbControl.SanPhams.SingleOrDefault(p => p.SanPhamID == strSanPhamID);
            if (Item!=null)
            {
                return (int) Item.SLTonKho;
    }
            else
            {
                return 0;
            }
        }

        static public int GetGiaVon(string strSanPhamID)
        {
            dbControl = new QlShop();
            SanPham Item = dbControl.SanPhams.SingleOrDefault(p => p.SanPhamID == strSanPhamID);
            if (Item != null)
            {
                return  (int)Item.GiaVon;
            }
            else 
            {
                return 0;
            }
        }
        /// <summary>
        /// Set trang thai ngung kinh doanh san pham
        /// </summary>
        /// <param name="strSanPhamID">Ma san pham muốn ngừng kinh doanh</param>
        static public void SetTrangThaiKinhDoanh(string strSanPhamID,bool bTrangThai)
        {
            dbControl = new QlShop();
            SanPham oItem = dbControl.SanPhams.SingleOrDefault(p => p.SanPhamID == strSanPhamID);
            if (oItem != null)
            {
                oItem.NgungKinhDoanh = bTrangThai;
                oItem.NguoiDungID = Utility.NguoiSuDung.NguoiDungID;
                oItem.TenNguoiDung = Utility.NguoiSuDung.TenNguoiDung;
                oItem.LastUpdate = DateTime.Now;
                dbControl.SaveChanges();
            }
        }

        static public SanPham GetItem(string strSanPhamID)
        {
            dbControl = new QlShop();
            return dbControl.SanPhams.SingleOrDefault(p => p.SanPhamID == strSanPhamID);
        }
        static public DataTable GetAllList()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_LayDanhSach").Tables[0];
        }

        /// <summary>
        /// Lấy danh sách sản phẩm đang kinh doanh
        /// </summary>
        /// <returns></returns>
        static public DataTable GetActiveList()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_SanPham_GetActiveList").Tables[0];
        }

        /// <summary>
        /// Kiểm tra sản phẩm với mã id đã có hay chưa
        /// </summary>
        /// <param name="intSanPhamID">Mã sản phẩm cần kiểm tra</param>
        /// <returns> true/false</returns>
        static public bool IsExitsItem(string intSanPhamID)
        { 
            dbControl = new QlShop();
            return dbControl.SanPhams.SingleOrDefault(p => p.SanPhamID == intSanPhamID) == null ? false : true;
        }
        /// <summary>
        /// Tao ma san pham tu dong với tiền tố và độ dài tham số truyền vào
        /// </summary>
        /// <param name="strPrefix">Tiền tố mã sản phẩm</param>
        /// <param name="intLeng">Độ dài mã sản phẩm</param>
        /// <returns>Mã sản phẩm được tạo ra</returns>
        static public string TaoMaSanPham(string strPrefix, int intLeng)
        {
            string strSanPhamID = string.Empty;
            return SqlHelper.ExecuteScalar(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_SanPham_TaoMaSanPham",
                new SqlParameter("@Prefix", strPrefix),
                new SqlParameter("@Lengt", intLeng)
                ).ToString();            
        }



        //16/6/2019
        //Bỏ cập nhật tồn kho, tính 
        static public void CapNhatTonKho(string strSanPhamID, int intSoLuong)
        {
            dbControl = new QlShop();
            SanPham oItem = new SanPham();
            oItem = dbControl.SanPhams.SingleOrDefault(p => p.SanPhamID == strSanPhamID);
            oItem.SLTonKho = oItem.SLTonKho - intSoLuong;
            dbControl.SaveChanges();
        }

        /// <summary>
        /// Lay ton kho tat ca ma hang trong he thong
        /// </summary>
        static public DataTable TonKhoHeThong()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_SanPham_TonKhoHeThong").Tables[0];
        }


        static public string GetIDFromExtID(string strExt_ID)
        {
            dbControl = new QlShop();
            SanPham objSanPham = dbControl.SanPhams.FirstOrDefault(p => p.EXT_ID == strExt_ID);
            if (objSanPham != null)
            {
                return objSanPham.SanPhamID;
            }
            else
            {
                return null;
            }
            //return dbControl.SanPhams.SingleOrDefault(p => p.SanPhamID == strSanPhamID);
        }

    }
}
