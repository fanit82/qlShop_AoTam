using System;
using System.Transactions;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;

namespace qlShop.models
{
    public static class PhieuGachNoController
    {
        static QlShop dbControl = null;
        static public void Add(PhieuGachNo item, List<PhieuGachNoChiTiet> items)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            using (TransactionScope scope = new TransactionScope())
            {
                item.CreateDate = DateTime.Now;
                item.LastUpdate = DateTime.Now;
                dbControl.PhieuGachNo.InsertOnSubmit(item);
                dbControl.PhieuGachNoChiTiet.InsertAllOnSubmit(items);

                foreach (PhieuGachNoChiTiet iPhieus in items)
                {
                    DonHangController.GachNo(iPhieus.DonHangID);
                }
                KhachHangController.GachNo(item.KhachHangID, item.TienThu);
                //cap nhat so luong ton kho

                //foreach (DonHangChiTiet DonHangItem in items)
                //{
                //    SanPhamController.CapNhatTonKho(DonHangItem.SanPhamID, DonHangItem.SoLuong);
                //}
                ////cap nha cong no va tong tien hang
                //if (item.KhachHangID != null)
                //{
                //    KhachHangController.CapNhatCongNo_MuaHang(item.KhachHangID, item.ConNo, item.TongCong);
                //}
                dbControl.SubmitChanges();
                scope.Complete();
            }
        }


        static public string TaoMaPhieuGachNo(string strPrefix, int intLeng)
        {
            return SqlHelper.ExecuteScalar(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_PhieuGachNo_TaoMa",
                new SqlParameter("@Prefix", strPrefix),
                new SqlParameter("@Lengt", intLeng)
                ).ToString();
        }

        static public DataSet TimPhieuTheoNgay(DateTime dtStart, DateTime dtEnd)
        {
            dtStart = dtStart.Date;
            dtEnd = dtEnd.Date.AddSeconds(86399);
            DataSet ds = null;
            ds = SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_PhieuGachNo_TimTheoNgay",
            new SqlParameter("@dtStart", dtStart),
            new SqlParameter("@dtEnd", dtEnd)
            );
            ds.Tables[0].TableName = "PhieuGachNo";
            ds.Tables[1].TableName = "PhieuGachNoChiTiet";
            DataColumn keyColum = ds.Tables[0].Columns["PhieuGachNoID"];
            DataColumn forenkey = ds.Tables[1].Columns["PhieuGachNoID"];
            ds.Relations.Add("PhieuGachNo_ChiTiet", keyColum, forenkey);
            return ds;
        }
    }
}
