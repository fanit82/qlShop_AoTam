using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;

namespace qlShop.models
{
    static public class NhaCungCapControlller
    {
        static QlShop dbControl = null;
        static public void Add(NhaCungCap item)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            item.CongNo = 0;
            item.TongTienHang = 0;
            //thong tin bao mat
            item.NguoiDungID = Utility.NguoiSuDung.NguoiDungID;
            item.TenNguoiDung = Utility.NguoiSuDung.TenNguoiDung;
            item.LastUpdate = DateTime.Now;
            dbControl.NhaCungCap.InsertOnSubmit(item);
            dbControl.SubmitChanges();
        }
        static public DataTable GetList()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_NhaCungCap_GetList").Tables[0];

        }
        static public NhaCungCap GetItem(string strNhaCungCapID)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            return dbControl.NhaCungCap.SingleOrDefault(p => p.NhaCungCapID == strNhaCungCapID);
        }
        static public void Edit(NhaCungCap item)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            NhaCungCap oItem = new NhaCungCap();
            oItem = dbControl.NhaCungCap.SingleOrDefault(p => p.NhaCungCapID == item.NhaCungCapID);
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
                dbControl.SubmitChanges();
            }
            dbControl.Dispose();
        }

        static public void DelItem(string strNhaCungCapID)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            NhaCungCap oItem = new NhaCungCap();
            oItem = dbControl.NhaCungCap.SingleOrDefault(p => p.NhaCungCapID == strNhaCungCapID);
            if (oItem != null)
            {
                dbControl.NhaCungCap.DeleteOnSubmit(oItem);
                dbControl.SubmitChanges();
            }
            dbControl.Dispose();
        }

        static public bool IsExitsItem(string strNhaCungCapID)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            return dbControl.NhaCungCap.SingleOrDefault(p => p.NhaCungCapID == strNhaCungCapID) == null ? false : true;
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
            dbControl = new QlShop(Utility.GetConnectString());
            NhaCungCap oItem = new NhaCungCap();
            oItem = dbControl.NhaCungCap.SingleOrDefault(p => p.NhaCungCapID == strNhaCungCap);
            oItem.CongNo = oItem.CongNo + decTienNo;
            oItem.TongTienHang = oItem.TongTienHang + decTienHang;
            dbControl.SubmitChanges();
        }
    }
}
