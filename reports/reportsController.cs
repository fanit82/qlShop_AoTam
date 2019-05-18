using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using qlShop.models;
using Microsoft.ApplicationBlocks.Data;

namespace qlShop.reports
{
    static class reportsController
    {
        //static QlShop dbControl = null;
        static public DataTable prtDonHang(string strDonHangID)
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_PRINT_PhieuBanHang", new SqlParameter("DonHangID", strDonHangID)).Tables[0];
        }
        static public DataTable prtTheKho(string strSanPhamID)
        {
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure,
                "NH_TheKho",
                new SqlParameter("SanPhamID", strSanPhamID)).Tables[0];
        }
        static public DataTable prtBaoCaoTongHop(int intThang, int intNam)
        {
            DataTable tb1 = SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure,
                "NH_BaoCaoTongHop",
                new SqlParameter("@THANG_LV", intThang),
                new SqlParameter("@NAM_LV", intNam)
                ).Tables[0];
            DateTime dt = new DateTime(intNam, intThang, 1);
            dt = dt.AddMonths(-1);
            DataTable tb2 = SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure,
                "NH_BaoCaoTongHop",
                new SqlParameter("@THANG_LV", dt.Month),
                new SqlParameter("@NAM_LV", dt.Year)
                ).Tables[0];

            //DataTable tbkReturn = new DataTable();
            //tbkReturn = tb2.Copy();
            //tbkReturn.Columns[1].ColumnName = "ThangTruoc";
            //tbkReturn.Columns.Add("ThangNay", typeof(Decimal));
            //for (int i = 0; i < tb2.Rows.Count; i++)
            //{
            //    tbkReturn.Rows[i]["ThangNay"] = tb1.Rows[i][1];
            //}

            DataTable tblTongHop = new DataTable();
            tblTongHop.Columns.Add("TieuDe",typeof(string));
            tblTongHop.Columns.Add("ThangNay", typeof(Decimal));
            tblTongHop.Columns.Add("ThangTruoc", typeof(Decimal));  
          
            tblTongHop.Rows.Add("Doanh Thu(1)", Convert.ToDecimal(tb2.Rows[0][1]), Convert.ToDecimal(tb1.Rows[0][1]));            
            tblTongHop.Rows.Add("Tổng vốn(2)", Convert.ToDecimal(tb2.Rows[1][1]), Convert.ToDecimal(tb1.Rows[1][1]));
            tblTongHop.Rows.Add("Khách nợ trong tháng(3)", Convert.ToDecimal(tb2.Rows[2][1]), Convert.ToDecimal(tb1.Rows[2][1]));
            tblTongHop.Rows.Add("Thu tiền bán hàng tháng(4)", Convert.ToDecimal(tb2.Rows[3][1]), Convert.ToDecimal(tb1.Rows[3][1]));
            tblTongHop.Rows.Add("Thu tiền nợ trong tháng(5)", Convert.ToDecimal(tb2.Rows[4][1]), Convert.ToDecimal(tb1.Rows[4][1]));
            tblTongHop.Rows.Add("Chi phí trong tháng(6)", Convert.ToDecimal(tb2.Rows[5][1]), Convert.ToDecimal(tb1.Rows[5][1]));
            tblTongHop.Rows.Add("Nhập hàng trong tháng(7)", Convert.ToDecimal(tb2.Rows[6][1]), Convert.ToDecimal(tb1.Rows[6][1]));
            //-------------------------------------------------------------
            tblTongHop.Rows.Add("Lợi nhuận thuần(8)=(1)-(2)",
                    Convert.ToDecimal(tb2.Rows[0][1]) - Convert.ToDecimal(tb2.Rows[1][1]),
                    Convert.ToDecimal(tb1.Rows[0][1]) - Convert.ToDecimal(tb1.Rows[1][1])
            );
            tblTongHop.Rows.Add("Lợi nhuận gộp(9)=(8)-(6)",
                    Convert.ToDecimal(tblTongHop.Rows[7][1]) - Convert.ToDecimal(tblTongHop.Rows[5][1]),
                    Convert.ToDecimal(tblTongHop.Rows[7][2]) - Convert.ToDecimal(tblTongHop.Rows[5][2])
            );
            tblTongHop.Rows.Add("Tiền thu trong tháng(10)=(4)+(5)",
                    Convert.ToDecimal(tb2.Rows[3][1]) - Convert.ToDecimal(tb2.Rows[4][1]),
                    Convert.ToDecimal(tb1.Rows[3][1]) - Convert.ToDecimal(tb1.Rows[4][1])
            );
            //-----------------------------------------------------------------------------
            return tblTongHop;
        }

        static public DataTable prtBaoCaoTongHopNgay(DateTime StartDate, DateTime EndDate)
        {
            StartDate = StartDate.Date;
            EndDate = EndDate.Date.AddSeconds(86399); //thời điểm cuối cùng trong ngày
            return SqlHelper.ExecuteDataset(Utility.GetConnectString(), CommandType.StoredProcedure, "NH_BaoCao_TongHopDonHangTheoNgay",
                new SqlParameter("StartDate", StartDate),
                new SqlParameter("EndDate", EndDate)                
                ).Tables[0];
        }
    }
}
