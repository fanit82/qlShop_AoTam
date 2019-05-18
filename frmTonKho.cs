using qlShop.models;
using qlShop.reports;
using System;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmTonKho : Form
    {
        public frmTonKho()
        {
            InitializeComponent();
        }

        private void KhoiTaoLuoi()
        {
            int i = 0;
            gridView1.Columns[i].Caption = "Mã sản phẩm";
            gridView1.Columns[i].FieldName = "SanPhamID";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Tên Sản phẩm";
            gridView1.Columns[i].FieldName = "TenSanPham";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Tồn kho";
            gridView1.Columns[i].FieldName = "SLTonKho";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Vốn tồn kho";
            gridView1.Columns[i].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            gridView1.Columns[i].UnboundExpression = "[SLTonKho]*[GiaVon]";           
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ### ###";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            gridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[i].SummaryItem.DisplayFormat = "Tổng tồn: {0:### ### ### ###}";

            i++;
            gridView1.Columns[i].Caption = "Giá trị tồn kho";
            gridView1.Columns[i].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            gridView1.Columns[i].UnboundExpression = "[SLTonKho]*[GiaBan]";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ### ###";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            gridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[i].SummaryItem.DisplayFormat = "Tổng giá trị tồn: {0:### ### ### ###}";

            i++;
            gridView1.Columns[i].Caption = "#";
            gridView1.Columns[i].OptionsColumn.FixedWidth = true;
            gridView1.Columns[i].Width = 50;

            gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;

            gridView1.OptionsView.ShowFooter = true;

            //gr_btn_del.Buttons[1].Visible = false;//Ẩn nút kinh doanh lại - vì mặc định đang hiển thị các sp kinh doanh
        }

        private void frmTonKho_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            gridControl1.DataSource = SanPhamController.GetActiveList();
            txtSearchSanPham.Properties.NullValuePrompt = "Tìm theo mã hoặc tên sản phẩm";
        }

        private void txtSearchSanPham_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.ActiveFilterString = string.Format("[SanPhamID] like '%{0}%' or TenSanPham like '%{0}%'", txtSearchSanPham.Text);
        }

        private void gr_btn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int intRow = gridView1.FocusedRowHandle;
            string strSanPhamID = string.Empty;
            if (intRow>=0)
            {
                strSanPhamID = gridView1.GetRowCellValue(intRow,"SanPhamID").ToString();
            }
            if (strSanPhamID!=string.Empty)
            {
                if (e.Button.Caption.ToUpper().Equals("THEKHO"))
                {
                    TheKho rpt = new TheKho();
                    rpt.SetDataSource(reportsController.prtTheKho(strSanPhamID));     
      
                    frmViewReports fReport = new frmViewReports();
                    fReport.crystalReportViewer1.ReportSource = rpt;
                    fReport.MdiParent = this.MdiParent;
                    fReport.Show();
                }
            }

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }
    }
}