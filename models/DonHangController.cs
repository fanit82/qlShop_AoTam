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
    class DonHangController
    {
        static QlShop dbControl = null;        
        static public void Add(DonHang item,List<DonHangChiTiet> items)
        {
            dbControl = new QlShop();
            using (TransactionScope scope = new TransactionScope())
            {
                //cap nhat so luong ton kho thuc te luc xuat
                foreach (DonHangChiTiet DonHangItem in items)
                {
                    DonHangItem.TonKho = SanPhamController.GetTonKho(DonHangItem.SanPhamID);
                    DonHangItem.GiaVon = SanPhamController.GetGiaVon(DonHangItem.SanPhamID);
                    //SanPhamController.CapNhatTonKho(DonHangItem.SanPhamID, DonHangItem.SoLuong);
                }
               
                dbControl.DonHangs.Add(item);                
                dbControl.DonHangChiTiets.AddRange(items);

                //cap nhat so luong ton kho

                foreach (DonHangChiTiet DonHangItem in items)
                {
                    SanPhamController.CapNhatTonKho(DonHangItem.SanPhamID, DonHangItem.SoLuong);
                }
                //cap nha cong no va tong tien hang
                if (item.KhachHangID!=null)
                {
                    KhachHangController.CapNhatCongNo_MuaHang(item.KhachHangID, item.ConNo, item.TongCong);    
                }
                //21/11/2015: fanit82
                //cap nha vo quy tien mat
                //---------------------------------

                decimal decTienMatThu = 0;
                decTienMatThu = item.KhachDua == null ? 0 : (decimal)item.KhachDua;
                /*
                    *Nếu khách đưa tiền mặt lớn hơn số tiền cần thanh toán
                    *thì phai thoi tien cho khach, và số tiền thực sự vô quỹ tiền mặt
                 * chỉ là số tiền khách thanh toán
                 * 
                 * 
                 */
                if (decTienMatThu>item.ThanhToan) 
                {
                    decTienMatThu = item.ThanhToan;
                }
                //decTienMatThu = item.KhachDua > item.ThanhToan ? item.ThanhToan : (decimal)item.KhachDua;

                QuyTienMatController.NhapQuyTienMat(item.DonHangID, item.NgayBan, decTienMatThu, "BH", "Tiền mặt bán hàng");
                //------------------end-------------
                dbControl.SaveChanges();
                scope.Complete();
            }            
        }

        /// <summary>
        /// Xoa don hang - bao gom ca don hang  chi tiet vaf cap nhat so luong cung nhu cong no
        /// </summary>
        /// <param name="strDonHangID">Don hang ID</param>
        static public void Del(string strDonHangID)
        {
            dbControl = new QlShop();
            DonHang DelItem = dbControl.DonHangs.SingleOrDefault(p => p.DonHangID == strDonHangID);
            if (DelItem!=null)
            {
                //lay danh sach san pham cua don hang
                List<DonHangChiTiet> ListSanPham = new List<DonHangChiTiet>();
                ListSanPham = (from p in dbControl.DonHangChiTiets
                             where p.DonHangID == strDonHangID
                             select p).ToList<DonHangChiTiet>();
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (DonHangChiTiet item in ListSanPham)
                    {
                        //cap nhat lai ton kho khi xoa
                        SanPhamController.CapNhatTonKho(item.SanPhamID, 0 - item.SoLuong);
                    }
                    //cap nhat lai con no khach hang va tien hang
                    if (DelItem.KhachHangID != null)
                    {
                        KhachHangController.CapNhatCongNo_MuaHang(DelItem.KhachHangID, 0 - DelItem.ConNo, 0 - DelItem.TongCong);
                    }
                    dbControl.DonHangs.Remove(DelItem);
                    dbControl.DonHangChiTiets.RemoveRange(ListSanPham);
                    dbControl.SaveChanges();
                    scope.Complete();
                }             
            }
        }

        static public DonHang GetItem(string strDonHangID)
        {
            dbControl = new QlShop();
            return dbControl.DonHangs.SingleOrDefault(p => p.DonHangID == strDonHangID);
        }

        static public DataTable GetSanPham(string strDonHangID)
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_DonHangChiTiet_GetSanPham",
                new SqlParameter("DonHangID", strDonHangID)
                ).Tables[0];
        
        }
        static public List<DonHangChiTiet> GetListSanPham(string strDonHangID)
        {
            List<DonHangChiTiet> ListItems = new List<DonHangChiTiet>();
            ListItems = (from p in dbControl.DonHangChiTiets
                       where p.DonHangID == strDonHangID
                       select p).ToList<DonHangChiTiet>();
            return ListItems;
        }
        static public DataTable GetAllList()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_DonHang_GetAllList").Tables[0];           
        }
        static public string TaoMaDonHang(string strPrefix, int intLeng)
        {            
            return SqlHelper.ExecuteScalar(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_DonHang_TaoMaDonHang",
                new SqlParameter("@Prefix", strPrefix),
                new SqlParameter("@Lengt", intLeng)
                ).ToString();
        }
        static public DataTable GetListRangDate(DateTime dtStart, DateTime dtEnd)
        {
            dtStart = dtStart.Date;
            dtEnd = dtEnd.Date.AddSeconds(86399); //thời điểm cuối cùng trong ngày
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_DonHang_GetListRangDate",
                new SqlParameter("@dtStart",dtStart),
                new SqlParameter("@dtEnd", dtEnd)
                ).Tables[0];
        }
        static public DataTable GetListInWeek()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_DonHang_GetListInWeek"
                ).Tables[0];
        }
        static public DataTable GetListInMonth()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_DonHang_GetListInMonth"
                ).Tables[0];
        }
        static public DataTable GetListInYear()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_DonHang_GetListInYear"
                ).Tables[0];
        }
        static public DataTable LayDonHangConNo_KhachHang(string strKhachHangID)
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_DONHANG_CONNO",
                new SqlParameter("KhachHangID", strKhachHangID)
                ).Tables[0];
        }


        static public void GachNo(string strDonHangID)
        {
            dbControl = new QlShop();
            DonHang item = dbControl.DonHangs.SingleOrDefault(p => p.DonHangID == strDonHangID);
            if (item!=null)
            {
                item.ConNo = 0;
                dbControl.SaveChanges();
            }
        }

        static public DataTable TraCuuChiTietDonHang(DateTime dtStart, DateTime dtEnd)
        {
            dtStart = dtStart.Date;
            dtEnd = dtEnd.Date.AddSeconds(86399); //thời điểm cuối cùng trong ngày
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_TraCuuChiTietDonHang",
                new SqlParameter("@dtStart", dtStart),
                new SqlParameter("@dtEnd", dtEnd)
                ).Tables[0];
        }
    }    
}
