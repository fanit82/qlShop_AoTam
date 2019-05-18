using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
namespace qlShop.models
{
    static class NhomHangController
    {        
        static QlShop dbControl = null;
        static public int Add(NhomHang item)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            dbControl.NhomHang.InsertOnSubmit(item);
            dbControl.SubmitChanges();
            return item.NhomHangID;
        }
        static public DataTable Getlist()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_NhomHang_LayDanhSach").Tables[0];
        }

        static public void Del(int intNhomHangID)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            NhomHang delItem = dbControl.NhomHang.SingleOrDefault(p=>p.NhomHangID==intNhomHangID);
            if (delItem!=null)
	        {
		        dbControl.NhomHang.DeleteOnSubmit(delItem);
                dbControl.SubmitChanges();
	        }            
        }

    }
}
