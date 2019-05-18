using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
namespace qlShop.models
{
    static public class NguoiDungController
    {
        static QlShop dbControl = null;

        static public void Add(NguoiDung item)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            item.CreateDate = DateTime.Now;            
            dbControl.NguoiDung.InsertOnSubmit(item);
            dbControl.SubmitChanges();
        }

        static public void Edit(NguoiDung item)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            NguoiDung oItem = new NguoiDung();
            oItem = dbControl.NguoiDung.SingleOrDefault(p => p.NguoiDungID == item.NguoiDungID);
            if (oItem != null)
            {
                oItem.TenNguoiDung = item.TenNguoiDung;
                oItem.Roles = item.Roles;
                oItem.MatKhau = item.MatKhau;
                oItem.LastUpdate = DateTime.Now;
                dbControl.SubmitChanges();
            }
            dbControl.Dispose();
        }

        static public void Del(string strNguoiDung)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            NguoiDung DelItem = dbControl.NguoiDung.SingleOrDefault(p => p.NguoiDungID == strNguoiDung);
            if (DelItem != null)
            {
                dbControl.NguoiDung.DeleteOnSubmit(DelItem);
                dbControl.SubmitChanges();
            }
        }
        static public NguoiDung GetItem(string strNguoiDungID)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            return dbControl.NguoiDung.SingleOrDefault(p => p.NguoiDungID == strNguoiDungID);
            
        }
        static public NguoiDung ChungThuc(string strUser, string Pass)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            return dbControl.NguoiDung.SingleOrDefault(p => p.NguoiDungID == strUser && p.MatKhau == Pass); 
        }

        static public void DoiPass(string strNguoiDungID,string strNewPass)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            NguoiDung oItem = new NguoiDung();
            oItem = dbControl.NguoiDung.SingleOrDefault(p => p.NguoiDungID == strNguoiDungID);
            if (oItem != null)
            {
                oItem.MatKhau = strNewPass;
                dbControl.SubmitChanges();
            }
            dbControl.Dispose();
        }
        static public DataTable GetList()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_NguoiDung_GetList").Tables[0];           
        }
    }
}
