using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;

namespace qlShop.models
{
    static public class LoaiChiPhiController
    {
        static QlShop dbControl = null;
        static public int Add(LoaiChiPhi item)
        {
            dbControl = new QlShop(Utility.GetConnectString());            
            dbControl.LoaiChiPhi.InsertOnSubmit(item);
            dbControl.SubmitChanges();
            return item.LoaiChiPhiID;
        }

        static public void Del(int intLoaiChiPhiID)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            LoaiChiPhi DelItem = dbControl.LoaiChiPhi.SingleOrDefault(p => p.LoaiChiPhiID == intLoaiChiPhiID);
            if (DelItem != null)
            {
                dbControl.LoaiChiPhi.DeleteOnSubmit(DelItem);
                dbControl.SubmitChanges();
            }
        }

        static public DataTable GetAllList()
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_LoaiChiPhi_GetAll").Tables[0];
        }
    }
}
