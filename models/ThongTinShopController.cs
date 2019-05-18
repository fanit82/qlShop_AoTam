using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;

namespace qlShop.models
{
    static class ThongTinShopController
    {
        static QlShop dbControl = null;
        public static ThongTinShop GetItem()
        {
            dbControl = new QlShop(Utility.GetConnectString());
            return dbControl.ThongTinShop.SingleOrDefault();
        }
        static public void Update(ThongTinShop item)
        {
            dbControl = new QlShop(Utility.GetConnectString());
            ThongTinShop oItem = new ThongTinShop();
            oItem = dbControl.ThongTinShop.SingleOrDefault();
            if (oItem != null)
            {
                oItem.TenShop = item.TenShop;
                oItem.SoDienThoai = item.SoDienThoai;
                oItem.DiaChi = item.DiaChi;
                oItem.Website = item.Website;
                
            }
            else
            {
                dbControl.ThongTinShop.InsertOnSubmit(item);
            }
            dbControl.SubmitChanges();
            dbControl.Dispose();
        }
    }
}
