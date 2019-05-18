using System;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
namespace qlShop.models
{
    class QuyTienMatController
    {
        static QlShop dbControl = null;
        static public void NhapQuyTienMat(string ChungTuID,DateTime dtNgayChungTu, decimal dcSoTien,string strPhanLoai,
            string strGhiChu)
        {
            QuyTienMat item = null;
            using (TransactionScope TSCope = new TransactionScope())
            {
                dbControl = new QlShop(Utility.GetConnectString());
                //kiểm tra nếu ngày hiện tại chưa có tiền trong quỹ thì làm thao tác kết chuyển ngày.                
                if (dbControl.QuyTienMat.FirstOrDefault(p => p.Ngay_ThaoTac.Date == dtNgayChungTu.Date) == null)
                {
                    item = new QuyTienMat();
                    item.Ngay_ThaoTac = DateTime.Now;
                    item.NgayChungTu = DateTime.Now;
                    item.PhanLoai = "KC";
                    item.TienDauKy = 0;
                    item.TienNhap = QuyTienMatController.TienTrongQuyHienTai();
                    item.TienXuat = 0;
                    item.GhiChu = "Kết chuyển tiền qua ngày";
                    dbControl.QuyTienMat.InsertOnSubmit(item);
                }
                item = new QuyTienMat();
                item.ChungTu_ID = ChungTuID;
                item.NgayChungTu = dtNgayChungTu;
                item.PhanLoai = strPhanLoai;
                item.GhiChu = strGhiChu;
                item.TienNhap = dcSoTien;
                item.TienXuat = 0;
                item.TienDauKy = TienTrongQuyHienTai();
                item.TienCuoiKy = item.TienDauKy + item.TienNhap;
                item.Ngay_ThaoTac = DateTime.Now;
                dbControl.QuyTienMat.InsertOnSubmit(item);
                dbControl.SubmitChanges();
                TSCope.Complete();
            }
        }
        static public void XuatQuyTienMat(string ChungTuID, DateTime dtNgayChungTu, decimal dcSoTien, string strPhanLoai,
    string strGhiChu)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            QuyTienMat item = null;
            using (TransactionScope TSCope = new TransactionScope())
            {
                if (dbControl.QuyTienMat.FirstOrDefault(p => p.Ngay_ThaoTac.Date == dtNgayChungTu.Date) == null)
                {
                    item = new QuyTienMat();
                    item.Ngay_ThaoTac = DateTime.Now;
                    item.NgayChungTu = DateTime.Now;
                    item.PhanLoai = "KC";
                    item.TienDauKy = 0;
                    item.TienNhap = QuyTienMatController.TienTrongQuyHienTai();
                    item.TienXuat = 0;
                    item.GhiChu = "Kết chuyển tiền qua ngày";
                    dbControl.QuyTienMat.InsertOnSubmit(item);
                }
                item = new QuyTienMat();
                item.ChungTu_ID = ChungTuID;
                item.NgayChungTu = dtNgayChungTu;
                item.PhanLoai = strPhanLoai;
                item.GhiChu = strGhiChu;
                item.TienNhap = 0;
                item.TienXuat = dcSoTien;
                item.TienDauKy = TienTrongQuyHienTai();
                item.TienCuoiKy = item.TienDauKy - item.TienXuat;
                item.Ngay_ThaoTac = DateTime.Now;
                dbControl.QuyTienMat.InsertOnSubmit(item);
                dbControl.SubmitChanges();
                TSCope.Complete();
            }

        }

        static public decimal TienTrongQuyHienTai()
        {
            var Obj = SqlHelper.ExecuteScalar(Utility.GetConnectString(), CommandType.StoredProcedure, "QuyTienMat_LayQuyHienTai");
            return Obj == null ? 0 : Convert.ToDecimal(Obj);           
        }
        static public QuyTienMat LayTrangThaiQuy(DateTime dtNgay)
        {
            DataTable tblReturn = SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "QuyTienMat_LayTrangThai").Tables[0];
            if ((tblReturn!=null) &&(tblReturn.Rows.Count!=0))
            {
                QuyTienMat item = new QuyTienMat();
                item.ChungTu_ID = tblReturn.Rows[0]["ChungTu_ID"].ToString();
                item.NgayChungTu =(DateTime) tblReturn.Rows[0]["NgayChungTu"];
                item.PhanLoai = tblReturn.Rows[0]["PhanLoai"].ToString();
                item.TienDauKy = Convert.ToDecimal(tblReturn.Rows[0]["TienDauKy"].ToString());
                item.TienNhap = Convert.ToDecimal(tblReturn.Rows[0]["TienNhap"].ToString());
                item.TienXuat = Convert.ToDecimal(tblReturn.Rows[0]["TienXuat"].ToString());
                item.TienCuoiKy = Convert.ToDecimal(tblReturn.Rows[0]["TienCuoiKy"].ToString());
                return item;
            }
            else
            {
                return null;
            }
        }
        static public DataTable LichSuGiaoDich(DateTime dtBegin, DateTime dtEnd)
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "QuyTienMat_LichSu",
                new SqlParameter("dtBegin", dtBegin),
                new SqlParameter("dtEnd", dtEnd)
                ).Tables[0];
        }
    }
}
