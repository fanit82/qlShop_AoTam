using qlShop.models;
using qlShop.reports;
using System;
using System.Drawing;
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
            gridView1.Columns[i].OptionsColumn.ReadOnly = true;

            i++;
            gridView1.Columns[i].Caption = "Tên Sản phẩm";
            gridView1.Columns[i].FieldName = "TenSanPham";
            gridView1.Columns[i].OptionsColumn.ReadOnly = true;

            i++;
            gridView1.Columns[i].Caption = "Size";
            gridView1.Columns[i].FieldName = "Size";
            gridView1.Columns[i].OptionsColumn.ReadOnly = true;

            i++;
            gridView1.Columns[i].Caption = "ĐVT";
            gridView1.Columns[i].FieldName = "DVT";
            gridView1.Columns[i].OptionsColumn.ReadOnly = true;

            i++;
            gridView1.Columns[i].Caption = "Giá Bán Lẻ";
            gridView1.Columns[i].FieldName = "GiaBan";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ### ###";
            gridView1.Columns[i].OptionsColumn.ReadOnly = true;

            i++;
            gridView1.Columns[i].Caption = "Tồn kho";
            gridView1.Columns[i].FieldName = "SoLuong";
            gridView1.Columns[i].OptionsColumn.ReadOnly = true;

            gridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[i].SummaryItem.DisplayFormat = "{0:### ### ### ###}";

            //i++;
            //gridView1.Columns[i].Caption = "Vốn tồn kho";
            //gridView1.Columns[i].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            //gridView1.Columns[i].UnboundExpression = "[SoLuong]*[GiaVon]";           
            //gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ### ###";
            //gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            //gridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //gridView1.Columns[i].SummaryItem.DisplayFormat = "Tổng tồn: {0:### ### ### ###}";

            i++;
            gridView1.Columns[i].Caption = "Giá trị tồn kho";
            gridView1.Columns[i].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            gridView1.Columns[i].UnboundExpression = "[SoLuong]*[GiaBan]";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ### ###";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            gridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;            
            gridView1.Columns[i].SummaryItem.DisplayFormat = "{0:### ### ### ###}";
            

            i++;
            gridView1.Columns[i].Caption = "#";
            gridView1.Columns[i].OptionsColumn.FixedWidth = true;
            gridView1.Columns[i].Width = 50;

            gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;

            gridView1.OptionsView.ShowFooter = true;
            gridView1.OptionsView.ColumnAutoWidth = false;

            gridView1.IndicatorWidth = 40;
            //gridView1.FooterPanelHeight = 20;
            //gr_btn_del.Buttons[1].Visible = false;//Ẩn nút kinh doanh lại - vì mặc định đang hiển thị các sp kinh doanh
        }

        private void frmTonKho_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            gridControl1.DataSource = SanPhamController.TonKhoHeThong();
            gridView1.BestFitColumns();
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

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.Kind == DevExpress.Utils.Drawing.IndicatorKind.Header)
            {
                e.Info.DisplayText = "STT";
            }
            else
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString("00");
            }
        }

        private void gridView1_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            e.Appearance.ForeColor = System.Drawing.Color.Red;
            //e.Appearance.FontSizeDelta = 10;
            //e.Appearance.ForeColor = System.Drawing.Color.Red;
            ////e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
            //e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds);
            //e.Handled = true;
        }
    }
}