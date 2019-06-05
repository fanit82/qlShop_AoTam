using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using qlShop.qlshop_model;
using Microsoft.ApplicationBlocks.Data;

namespace qlShop.models
{
    static public class LoaiChiPhiController
    {
        static QlShop dbControl = null;
        static public int Add(LoaiChiPhi item)
        {
            dbControl = new QlShop();            
            dbControl.LoaiChiPhis.Add(item);
            dbControl.SaveChanges();
            return item.LoaiChiPhiID;
        }

        static public void Del(int intLoaiChiPhiID)
        {
            dbControl = new QlShop();
            LoaiChiPhi DelItem = dbControl.LoaiChiPhis.SingleOrDefault(p => p.LoaiChiPhiID == intLoaiChiPhiID);
            if (DelItem != null)
            {
                dbControl.LoaiChiPhis.Remove(DelItem);
                dbControl.SaveChanges();
            }
        }

        static public DataTable GetAllList()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_LoaiChiPhi_GetAll").Tables[0];
        }
    }
}
