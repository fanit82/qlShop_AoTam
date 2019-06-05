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
    static public class NhaCungCapControlller
    {
        static QlShop dbControl = null;
        static public void Add(NhaCungCap item)
        {
            dbControl = new QlShop();
            item.CongNo = 0;
            item.TongTienHang = 0;
            //thong tin bao mat
            item.NguoiDungID = Utility.NguoiSuDung.NguoiDungID;
            item.TenNguoiDung = Utility.NguoiSuDung.TenNguoiDung;
            item.LastUpdate = DateTime.Now;
            dbControl.NhaCungCaps.Add(item);
            dbControl.SaveChanges();
        }
        static public DataTable GetList()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_NhaCungCap_GetList").Tables[0];

        }
        static public NhaCungCap GetItem(string strNhaCungCapID)
        {
            dbControl = new QlShop();
            return dbControl.NhaCungCaps.SingleOrDefault(p => p.NhaCungCapID == strNhaCungCapID);
        }
        static public void Edit(NhaCungCap item)
        {
            dbControl = new QlShop();
            NhaCungCap oItem = new NhaCungCap();
            oItem = dbControl.NhaCungCaps.SingleOrDefault(p => p.NhaCungCapID == item.NhaCungCapID);
            if (oItem != null)
            {
                oItem.TenNhaCungCap = item.TenNhaCungCap;
                oItem.SoDienThoai = item.SoDienThoai;
                oItem.MST = item.MST;
                oItem.NguoiLienHe = item.NguoiLienHe;
                oItem.GhiChu = item.GhiChu;
                //thong tin bao mat
                oItem.NguoiDungID = Utility.NguoiSuDung.NguoiDungID;
                oItem.TenNguoiDung = Utility.NguoiSuDung.TenNguoiDung;
                oItem.LastUpdate = DateTime.Now;
                dbControl.SaveChanges();
            }
            dbControl.Dispose();
        }

        static public void DelItem(string strNhaCungCapID)
        {
            dbControl = new QlShop();
            NhaCungCap oItem = new NhaCungCap();
            oItem = dbControl.NhaCungCaps.SingleOrDefault(p => p.NhaCungCapID == strNhaCungCapID);
            if (oItem != null)
            {
                dbControl.NhaCungCaps.Remove(oItem);
                dbControl.SaveChanges();
            }
            dbControl.Dispose();
        }

        static public bool IsExitsItem(string strNhaCungCapID)
        {
            dbControl = new QlShop();
            return dbControl.NhaCungCaps.SingleOrDefault(p => p.NhaCungCapID == strNhaCungCapID) == null ? false : true;
        }


        static public string TaoMaNhaCungCap(string strPrefix, int intLeng)
        {
            return SqlHelper.ExecuteScalar(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_NhaCungCap_TaoMa",
                new SqlParameter("@Prefix", strPrefix),
                new SqlParameter("@Lengt", intLeng)
                ).ToString();
        }

        static public void CapNhatCongNo_NhapHang(string strNhaCungCap, decimal decTienNo, decimal decTienHang)
        {
            dbControl = new QlShop();
            NhaCungCap oItem = new NhaCungCap();
            oItem = dbControl.NhaCungCaps.SingleOrDefault(p => p.NhaCungCapID == strNhaCungCap);
            oItem.CongNo = oItem.CongNo + decTienNo;
            oItem.TongTienHang = oItem.TongTienHang + decTienHang;
            dbControl.SaveChanges();
        }
    }
}
