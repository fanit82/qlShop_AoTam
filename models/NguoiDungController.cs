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
    static public class NguoiDungController
    {
        static QlShop dbControl = null;

        static public void Add(NguoiDung item)
        {
            dbControl = new QlShop();
            item.CreateDate = DateTime.Now;            
            dbControl.NguoiDungs.Add(item);
            dbControl.SaveChanges();
        }

        static public void Edit(NguoiDung item)
        {
            dbControl = new QlShop();
            NguoiDung oItem = new NguoiDung();
            oItem = dbControl.NguoiDungs.SingleOrDefault(p => p.NguoiDungID == item.NguoiDungID);
            if (oItem != null)
            {
                oItem.TenNguoiDung = item.TenNguoiDung;
                oItem.Roles = item.Roles;
                oItem.MatKhau = item.MatKhau;
                oItem.LastUpdate = DateTime.Now;
                dbControl.SaveChanges();
            }
            dbControl.Dispose();
        }

        static public void Del(string strNguoiDung)
        {
            dbControl = new QlShop();
            NguoiDung DelItem = dbControl.NguoiDungs.SingleOrDefault(p => p.NguoiDungID == strNguoiDung);
            if (DelItem != null)
            {
                dbControl.NguoiDungs.Remove(DelItem);
                dbControl.SaveChanges();
            }
        }
        static public NguoiDung GetItem(string strNguoiDungID)
        {
            dbControl = new QlShop();
            return dbControl.NguoiDungs.SingleOrDefault(p => p.NguoiDungID == strNguoiDungID);
            
        }
        static public NguoiDung ChungThuc(string strUser, string Pass)
        {
            dbControl = new QlShop();
            return dbControl.NguoiDungs.SingleOrDefault(p => p.NguoiDungID == strUser && p.MatKhau == Pass); 
        }

        static public void DoiPass(string strNguoiDungID,string strNewPass)
        {
            dbControl = new QlShop();
            NguoiDung oItem = new NguoiDung();
            oItem = dbControl.NguoiDungs.SingleOrDefault(p => p.NguoiDungID == strNguoiDungID);
            if (oItem != null)
            {
                oItem.MatKhau = strNewPass;
                dbControl.SaveChanges();
            }
            dbControl.Dispose();
        }
        static public DataTable GetList()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_NguoiDung_GetList").Tables[0];           
        }
    }
}
