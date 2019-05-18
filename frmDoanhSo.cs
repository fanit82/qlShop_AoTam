using qlShop.reports;
using System;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmDoanhSo : Form
    {
        public frmDoanhSo()
        {
            InitializeComponent();
        }

        private void KhoiTaoLuoi()
        {
            int i = 0;
            gridView1.Columns[i].Caption = "Ngày";
            gridView1.Columns[i].FieldName = "NgayBan";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns[i].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            //gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Đơn hàng";
            gridView1.Columns[i].FieldName = "DonHangID";
            //gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Khách hàng";
            gridView1.Columns[i].FieldName = "TenKhachHang";
            //gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Điện thoại";
            gridView1.Columns[i].FieldName = "SoDienThoai";
            //gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            i++;
            gridView1.Columns[i].Caption = "Tiền hàng";
            gridView1.Columns[i].FieldName = "TienHang";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";
            //gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            gridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[i].SummaryItem.DisplayFormat = "{0:### ### ##0}";

            i++;
            gridView1.Columns[i].Caption = "Giảm giá";
            gridView1.Columns[i].FieldName = "GiamGia";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";
            gridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[i].SummaryItem.DisplayFormat = "{0:### ### ##0}";

            i++;
            gridView1.Columns[i].Caption = "Phải trả";
            gridView1.Columns[i].FieldName = "TongCong";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";
            //gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            gridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[i].SummaryItem.DisplayFormat = "{0:### ### ##0}";


            i++;
            gridView1.Columns[i].Caption = "Đã thanh toán";
            gridView1.Columns[i].FieldName = "ThanhToan";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";
            gridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[i].SummaryItem.DisplayFormat = "{0:### ### ##0}";
            //gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Nợ";
            gridView1.Columns[i].FieldName = "ConNo";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";
            gridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[i].SummaryItem.DisplayFormat = "{0:### ### ##0}";
            //gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Số món hàng";
            gridView1.Columns[i].FieldName = "SoMonHang";
            gridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[i].SummaryItem.DisplayFormat = "{0:### ### ##0}";
            //gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";
            //gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Tiền vốn";
            gridView1.Columns[i].FieldName = "TienVon";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";
            gridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[i].SummaryItem.DisplayFormat = "{0:### ### ##0}";
            //gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Tiền lời";
            gridView1.Columns[i].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            gridView1.Columns[i].UnboundExpression = "[TongCong] - [TienVon]";
            //gridView1.Columns[i].FieldName = "TienVon";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";
            gridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[i].SummaryItem.DisplayFormat = "{0:### ### ##0}";
            //gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Nhân viên";
            gridView1.Columns[i].FieldName = "TenNhanVien";
            //gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            gridView1.OptionsView.ShowFooter = true;
            for (int j = 0; j < gridView1.RowCount; j++)
            {
                gridView1.Columns[j].OptionsColumn.ReadOnly = true;
            }
        }

        private void frmDoanhSo_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            //gridControl1.DataSource = DonHangController.GetListRangDate(DateTime.Now, DateTime.Now);
            dateEditStart.DateTime = DateTime.Now;
            dateEditEnd.DateTime = DateTime.Now;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            DateTime DateStart = new DateTime();
            DateTime DateEnd = new DateTime();
            if (dateEditStart.EditValue!=null)
            {
                DateStart = dateEditStart.DateTime;
            }
            if (dateEditEnd.EditValue != null)
            {
                DateEnd = dateEditEnd.DateTime;
            }
            //gridControl1.DataSource = DonHangController.GetListRangDate(DateStart, DateEnd);
            gridControl1.DataSource = reportsController.prtBaoCaoTongHopNgay(DateStart, DateEnd);

            
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog opf = new SaveFileDialog())
            {
                opf.Title = "Xuất excel";
                opf.Filter = "Execl files (*.xls)|*.xls";
                if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string strFile = opf.FileName;
                    gridView1.ExportToXls(strFile);
                    System.Diagnostics.Process.Start(strFile);
                }
            }  
        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            DateTime dtMonday = DateTime.Today;
            int offset = dtMonday.DayOfWeek - DayOfWeek.Monday;
            dtMonday = dtMonday.AddDays(0-offset);
            dateEditStart.EditValue = dtMonday;
            dateEditEnd.EditValue = dtMonday.AddDays(6);
            simpleButton4.PerformClick();
            //gridControl1.DataSource = DonHangController.GetListInWeek();
        }
        private void btnMonth_Click(object sender, EventArgs e)
        {
            DateTime dtToday = DateTime.Today;
            dtToday = new DateTime(dtToday.Year, dtToday.Month, 1);
            dateEditStart.EditValue = dtToday;
            dateEditEnd.EditValue = dtToday.AddMonths(1).AddDays(-1);
            simpleButton4.PerformClick();
            //gridControl1.DataSource = DonHangController.GetListInMonth();
        }

        private void btnYear_Click(object sender, EventArgs e)
        {
            DateTime dtToday = DateTime.Today;
            dtToday = new DateTime(dtToday.Year, 1, 1);
            dateEditStart.EditValue = dtToday;
            dateEditEnd.EditValue = dtToday.AddYears(1).AddDays(-1);
            simpleButton4.PerformClick();
            //gridControl1.DataSource = DonHangController.GetListInYear();
        }
    }
}
