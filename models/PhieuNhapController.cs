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
    static public class PhieuNhapController
    {
        static QlShop dbControl = null;
        static public void Add(PhieuNhap item, List<PhieuNhapChiTiet> items)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            using (TransactionScope scope = new TransactionScope())
            {
                dbControl.PhieuNhap.InsertOnSubmit(item);
                dbControl.PhieuNhapChiTiet.InsertAllOnSubmit(items);


                //cap nhat so luong ton kho

                foreach (PhieuNhapChiTiet PhieuNhapItem in items)
                {
                    SanPhamController.CapNhatTonKho(PhieuNhapItem.SanPhamID, 0 - PhieuNhapItem.SoLuong);
                }
                //cap nha cong no va tong tien hang
                if (item.NhaCungCapID != null)
                {
                    NhaCungCapControlller.CapNhatCongNo_NhapHang(item.NhaCungCapID, item.ConNo, item.TienHang);
                }
                dbControl.SubmitChanges();
                scope.Complete();
            }
        }


        static public void Del(string strPhieuNhapID)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            PhieuNhap DelItem = dbControl.PhieuNhap.SingleOrDefault(p => p.PhieuNhapID == strPhieuNhapID);
            if (DelItem != null)
            {
                //lay danh sach san pham cua don hang
                List<PhieuNhapChiTiet> ListSanPham = new List<PhieuNhapChiTiet>();
                ListSanPham = (from p in dbControl.PhieuNhapChiTiet
                               where p.PhieuNhapID == strPhieuNhapID
                               select p).ToList<PhieuNhapChiTiet>();
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (PhieuNhapChiTiet item in ListSanPham)
                    {
                        //cap nhat lai ton kho khi xoa
                        SanPhamController.CapNhatTonKho(item.SanPhamID, item.SoLuong);
                    }
                    //cap nhat lai con no khach hang va tien hang
                    if (DelItem.NhaCungCapID != null)
                    {
                        NhaCungCapControlller.CapNhatCongNo_NhapHang(DelItem.NhaCungCapID, 0 -DelItem.ConNo, 0 - DelItem.TienHang);
                    }
                    dbControl.PhieuNhap.DeleteOnSubmit(DelItem);
                    dbControl.PhieuNhapChiTiet.DeleteAllOnSubmit(ListSanPham);
                    dbControl.SubmitChanges();
                    scope.Complete();
                }
            }
        }

        static public string TaoMaPhieuNhap(string strPrefix, int intLeng)
        {
            return SqlHelper.ExecuteScalar(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_PhieuNhap_TaoMaPhieuNhap",
                new SqlParameter("@Prefix", strPrefix),
                new SqlParameter("@Lengt", intLeng)
                ).ToString();
        }

        static public DataTable GetAllList()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_PhieuNhap_GetAllList").Tables[0];
        }


        static public PhieuNhap GetItem(string strPhieuNhapID)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            return dbControl.PhieuNhap.SingleOrDefault(p => p.PhieuNhapID == strPhieuNhapID);
        }


        static public DataTable GetSanPham(string strDonHangID)
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_PhieuNhapChiTiet_GetSanPham",
                new SqlParameter("PhieuNhapID", strDonHangID)
                ).Tables[0];

        }
    }
}
