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

    }
}
