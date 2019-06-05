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
    static public class KhachHangController
    {
        static QlShop dbControl = null;
        static public void Add(KhachHang item)
        {
            dbControl = new QlShop();
            item.CongNo = 0;
            item.TongTienHang = 0;
            dbControl.KhachHangs.Add(item);
            dbControl.SaveChanges();
        }
        static public KhachHang GetItem(string strKhachHangID)
        { 
            dbControl = new QlShop();
            return dbControl.KhachHangs.SingleOrDefault(p => p.KhachHangID == strKhachHangID);
        }

        static public void Edit(KhachHang item)
        {
            dbControl = new QlShop();
            KhachHang oItem = new KhachHang();
            oItem = dbControl.KhachHangs.SingleOrDefault(p => p.KhachHangID == item.KhachHangID);
            if (oItem!=null)
            {
                oItem.TenKhachHang = item.TenKhachHang;
                oItem.SoDienThoai = item.SoDienThoai;
                oItem.SinhNhat = item.SinhNhat;
                oItem.GioiTinh = item.GioiTinh;
                oItem.DiaChi = item.DiaChi;
                oItem.GhiChu = item.GhiChu;
                //thong tin bao mat
                oItem.NguoiDungID = Utility.NguoiSuDung.NguoiDungID;
                oItem.TenNguoiDung = Utility.NguoiSuDung.TenNguoiDung;
                oItem.LastUpdate = DateTime.Now;
                dbControl.SaveChanges();
            }
            dbControl.Dispose();
        }
        static public void DelItem(string strKhachHangID)
        {
            dbControl = new QlShop();
            KhachHang oItem = new KhachHang();
            oItem = dbControl.KhachHangs.SingleOrDefault(p => p.KhachHangID == strKhachHangID);
            if (oItem!=null)
            {
                dbControl.KhachHangs.Remove(oItem);
                dbControl.SaveChanges();
            }
            dbControl.Dispose();
        }

        static public DataTable GetList()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_KhachHang_LayDanhSach").Tables[0];

        }

        static public bool IsExitsItem(string KhachHangID)
        {
            dbControl = new QlShop();
            return dbControl.KhachHangs.SingleOrDefault(p => p.KhachHangID == KhachHangID) == null ? false : true;
        }

        static public string TaoMaKhachHang(string strPrefix, int intLeng)
        {
            string strSanPhamID = string.Empty;
            return SqlHelper.ExecuteScalar(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_KhachHang_TaoMa",
                new SqlParameter("@Prefix", strPrefix),
                new SqlParameter("@Lengt", intLeng)
                ).ToString();
        }

        static public void CapNhatCongNo_MuaHang(string strKhachHangID, decimal decTienNo,decimal decTienHang)
        {
            dbControl = new QlShop();
            KhachHang oItem = new KhachHang();
            oItem = dbControl.KhachHangs.SingleOrDefault(p => p.KhachHangID == strKhachHangID);
            oItem.CongNo = oItem.CongNo + decTienNo;
            oItem.TongTienHang = oItem.TongTienHang + decTienHang;
            dbControl.SaveChanges();
        }

        static public void GachNo(string strKhachHangID, decimal decSoTien)
        {
            dbControl = new QlShop();
            KhachHang oItem = null;
            oItem = dbControl.KhachHangs.SingleOrDefault(p => p.KhachHangID == strKhachHangID);
            if (oItem!=null)
            {
                oItem.CongNo -= decSoTien;
                dbControl.SaveChanges();
            }
        }

        /// <summary>
        /// Lấy danh sách khách hàng sinh nhật hôm nay
        /// </summary>
        /// <returns></returns>
        static public DataTable DanhSachSinhNhat()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_KhachHang_SinhNhat").Tables[0];            
        }
    }
}
