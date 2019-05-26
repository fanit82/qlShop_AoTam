using System;
using System.Data;
using System.Transactions;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using qlShop.models;
using qlShop.qlshop_model;

namespace qlShop.models
{
    static public class ChiPhiController
    {
        static QlShop dbControl = null;
        static public int  Add(ChiPhi item)
        {
            using (TransactionScope Tscope = new TransactionScope())
            {
                dbControl = new QlShop();
                item.LastUpdate = DateTime.Now;
                item.CreateDate = DateTime.Now;
                item.NguoiDungID = Utility.NguoiSuDung.NguoiDungID;
                item.TenNguoiDung = Utility.NguoiSuDung.TenNguoiDung;
                //dbControl.ChiPhi.InsertOnSubmit(item);
                dbControl.ChiPhis.Add()
                dbControl.SaveChanges();
                QuyTienMatController.XuatQuyTienMat(item.ChiPhiID.ToString(), item.NgayChi, item.SoTien, "CP", "TT chi phí");
                Tscope.Complete();
            }
            return item.ChiPhiID;
        }
        static public void Del(int intChiPhiID)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            ChiPhi DelItem = dbControl.ChiPhi.SingleOrDefault(p => p.ChiPhiID == intChiPhiID);
            if (DelItem != null)
            {
                dbControl.ChiPhi.DeleteOnSubmit(DelItem);
                dbControl.SubmitChanges();
            }
        }

        static public void Edit(ChiPhi item)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            ChiPhi oItem = new ChiPhi();
            oItem = dbControl.ChiPhi.SingleOrDefault(p => p.ChiPhiID == item.ChiPhiID);
            if (oItem != null)
            {
                oItem.TenChiPhi = item.TenChiPhi;
                oItem.NgayChi = item.NgayChi;
                oItem.LoaiChiPhiID = item.LoaiChiPhiID;
                oItem.TenLoaiChiPhi = item.TenLoaiChiPhi;
                oItem.SoTien = item.SoTien;
                oItem.GhiChu = item.GhiChu;
                //--thông tin bao mật
                oItem.NguoiDungID = Utility.NguoiSuDung.NguoiDungID;
                oItem.TenNguoiDung = Utility.NguoiSuDung.TenNguoiDung;
                oItem.LastUpdate = DateTime.Now;
                dbControl.SubmitChanges();
            }
            dbControl.Dispose();
        }

        static public ChiPhi GetITem(int intChiPhiID)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            return dbControl.ChiPhi.SingleOrDefault(p => p.ChiPhiID == intChiPhiID);
        }
        static public DataTable GetAllList()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_ChiPhi_GetAll").Tables[0];
        }


    }
}
