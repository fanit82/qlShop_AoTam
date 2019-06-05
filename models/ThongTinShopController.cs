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
    static class ThongTinShopController
    {
        static QlShop dbControl = null;
        public static ThongTinShop GetItem()
        {
            dbControl = new QlShop();
            return dbControl.ThongTinShops.SingleOrDefault();
        }
        static public void Update(ThongTinShop item)
        {
            dbControl = new QlShop();
            ThongTinShop oItem = new ThongTinShop();
            oItem = dbControl.ThongTinShops.SingleOrDefault();
            if (oItem != null)
            {
                oItem.TenShop = item.TenShop;
                oItem.SoDienThoai = item.SoDienThoai;
                oItem.DiaChi = item.DiaChi;
                oItem.website = item.website;
                
            }
            else
            {
                dbControl.ThongTinShops.Add(item);
            }
            dbControl.SaveChanges();
            dbControl.Dispose();
        }
    }
}
