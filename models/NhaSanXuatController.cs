using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
namespace qlShop.models
{
    class NhaSanXuatController
    {
        static QlShop dbControl = null;
        static public int Add(NhaSanXuat item)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            dbControl.NhaSanXuat.InsertOnSubmit(item);
            dbControl.SubmitChanges();
            return item.NhaSanXuatID;
        }
        static public DataTable GetList()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_NhaSanXuat_LayDanhSach").Tables[0];
        }
        static public void Del(int intNhaSanXuatID)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            NhaSanXuat item = dbControl.NhaSanXuat.SingleOrDefault(p => p.NhaSanXuatID == intNhaSanXuatID);
            if (item !=null)
            {
                dbControl.NhaSanXuat.DeleteOnSubmit(item);
                dbControl.SubmitChanges();
            }
        }
    }
}
