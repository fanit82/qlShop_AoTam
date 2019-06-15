using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using qlShop.qlshop_model;

namespace qlShop.models
{
    static class NhomHangController
    {        
        static QlShop dbControl = null;
        static public int Add(NhomHang item)
        {
            dbControl = new QlShop();
            if (item.LastUpdate == null) item.LastUpdate = DateTime.Now;
            dbControl.NhomHangs.Add(item);
            dbControl.SaveChanges();
            return item.NhomHangID;
        }
        static public DataTable Getlist()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_NhomHang_LayDanhSach").Tables[0];
        }

        static public void Del(int intNhomHangID)
        {
            dbControl = new QlShop();
            NhomHang delItem = dbControl.NhomHangs.SingleOrDefault(p=>p.NhomHangID==intNhomHangID);
            if (delItem!=null)
	        {
		        dbControl.NhomHangs.Remove(delItem);
                dbControl.SaveChanges();
	        }            
        }

        static public int CountByName(string strTenNhomHang)
        {
            return dbControl.NhomHangs.Count(p => p.TenNhomHang == strTenNhomHang);
        }

        static public NhomHang GetByName(string strTenNhomHang)
        {
            dbControl = new QlShop();
            return dbControl.NhomHangs.SingleOrDefault(p => p.TenNhomHang == strTenNhomHang);            
        }
    }
}
