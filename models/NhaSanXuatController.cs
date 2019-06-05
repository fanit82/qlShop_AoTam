using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using qlShop.qlshop_model;

namespace qlShop.models
{
    class NhaSanXuatController
    {
        static QlShop dbControl = null;
        static public int Add(NhaSanXuat item)
        {
            dbControl = new QlShop();
            dbControl.NhaSanXuats.Add(item);
            dbControl.SaveChanges();
            return item.NhaSanXuatID;
        }
        static public DataTable GetList()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_NhaSanXuat_LayDanhSach").Tables[0];
        }
        static public void Del(int intNhaSanXuatID)
        {
            dbControl = new QlShop();
            NhaSanXuat item = dbControl.NhaSanXuats.SingleOrDefault(p => p.NhaSanXuatID == intNhaSanXuatID);
            if (item !=null)
            {
                dbControl.NhaSanXuats.Remove(item);
                dbControl.SaveChanges();
            }
        }
    }
}
