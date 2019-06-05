using System;
using System.Transactions;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using qlShop.qlshop_model;

namespace qlShop.models
{
    class TraHangController
    {
        static QlShop dbControl = null;

        static public string TaoMaTraHang(string strPrefix, int intLeng)
        {
            return SqlHelper.ExecuteScalar(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_TraHang_TaoMaTraHang",
                new SqlParameter("@Prefix", strPrefix),
                new SqlParameter("@Lengt", intLeng)
                ).ToString();
        }


        static public void Add(TraHang item, List<TraHangChiTiet> items)
        {
            dbControl = new QlShop();
            using (TransactionScope scope = new TransactionScope())
            {
                item.TraHangID = TaoMaTraHang("RT", 8);
                //cap nhat so luong ton kho thuc te luc xuat
                foreach (TraHangChiTiet TraHangItem in items)
                {
                    TraHangItem.TraHangID = item.TraHangID;
                    TraHangItem.TonKho = SanPhamController.GetTonKho(TraHangItem.SanPhamID);
                    TraHangItem.GiaVon = SanPhamController.GetGiaVon(TraHangItem.SanPhamID);
                    //SanPhamController.CapNhatTonKho(DonHangItem.SanPhamID, DonHangItem.SoLuong);
                }
                
                dbControl.TraHangs.Add(item);
                dbControl.TraHangChiTiets.AddRange(items);
                //cap nhat so luong ton kho

                foreach (TraHangChiTiet TraHangItem in items)
                {
                    SanPhamController.CapNhatTonKho(TraHangItem.SanPhamID, 0 - TraHangItem.SoLuongTra);
                }
                //cap nha cong no va tong tien hang
                //if (item.KhachHangID != null)
                //{
                //    KhachHangController.CapNhatCongNo_MuaHang(item.KhachHangID, item.ConNo, item.TongCong);
                //}
                //21/11/2015: fanit82
                //cap nha vo quy tien mat
                //---------------------------------
                //QuyTienMatController.NhapQuyTienMat(item.DonHangID, item.NgayBan, item.ThanhToan, "BH", "Tiền mặt bán hàng");
                //------------------end-------------
                dbControl.SaveChanges();
                scope.Complete();
            }
        }


        static public TraHang GetItem(string strTraHangID)
        {
            dbControl = new QlShop();
            return dbControl.TraHangs.SingleOrDefault(p => p.TraHangID == strTraHangID);
        }


        static public DataTable GetListRangDate(DateTime dtStart, DateTime dtEnd)
        {
            dtStart = dtStart.Date;
            dtEnd = dtEnd.Date.AddSeconds(86399); //thời điểm cuối cùng trong ngày
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_TraHang_GetListRangDate",
                new SqlParameter("@dtStart", dtStart),
                new SqlParameter("@dtEnd", dtEnd)
                ).Tables[0];
        }


        static public DataTable GetDetails(string strDonHangID)
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_TraHangChiTiet_GetSanPham",
                new SqlParameter("TraHangID", strDonHangID)
                ).Tables[0];

        }
    }
}
