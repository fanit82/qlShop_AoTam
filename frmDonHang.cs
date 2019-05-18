using qlShop.models;
using qlShop.reports;
using System;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmDonHang : Form
    {
        public frmDonHang()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddDonHang f = new frmAddDonHang();            
            f.MdiParent= this.MdiParent;
            f.Show();
            this.Dispose();
        }
        private void KhoiTaoLuoi()
        {
            gridView1.IndicatorWidth = 50;
            //gridView1.
            int i = 0;
            gridView1.Columns[i].Caption = "Ngày";
            gridView1.Columns[i].FieldName = "NgayBan";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns[i].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Đơn hàng";
            gridView1.Columns[i].FieldName = "DonHangID";
            gridView1.Columns[i].OptionsColumn.ReadOnly = true;

            i++;
            gridView1.Columns[i].Caption = "Khách hàng";
            gridView1.Columns[i].FieldName = "TenKhachHang";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Điện thoại";
            gridView1.Columns[i].FieldName = "SoDienThoai";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Tiền hàng";
            gridView1.Columns[i].FieldName = "TienHang";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Giảm giá";
            gridView1.Columns[i].FieldName = "GiamGia";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Tổng cộng";
            gridView1.Columns[i].FieldName = "TongCong";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Thanh toán";
            gridView1.Columns[i].FieldName = "ThanhToan";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Nợ";
            gridView1.Columns[i].FieldName = "ConNo";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Nhân viên";
            gridView1.Columns[i].FieldName = "TenNhanVien";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "#";
            gridView1.Columns[i].OptionsColumn.FixedWidth = true;
            gridView1.Columns[i].Width = 70;

            gridView1.OptionsView.ShowFilterPanelMode =  DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            gridView1.OptionsView.ColumnAutoWidth = false;
            //for (int j = 0; j < gridView1.RowCount; j++)
            //{
            //    gridView1.Columns[j].OptionsColumn.AllowEdit = false;
            //}

            //------------------------------------------------------------------------------------------------
            // khoi tao luoi chi tiet gridview2
            i = 0;
           
            gridView2.Columns[i].Caption = "Sản phẩm";
            gridView2.Columns[i].FieldName = "SanPhamID";

            i++;
            gridView2.Columns[i].Caption = "Tên Sản phẩm";
            gridView2.Columns[i].FieldName = "TenSanPham";

            i++;
            gridView2.Columns[i].Caption = "Số lượng";
            gridView2.Columns[i].FieldName = "SoLuong";

            i++;
            gridView2.Columns[i].Caption = "Đơn giá";
            gridView2.Columns[i].FieldName = "DonGia";
            gridView2.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView2.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";

            i++;
            gridView2.Columns[i].Caption = "Thành tiền";
            gridView2.Columns[i].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            gridView2.Columns[i].UnboundExpression = "[DonGia]*[SoLuong]";
            gridView2.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView2.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";
            for (int k = 0; k < gridView2.Columns.Count; k++)
            {
                gridView2.Columns[k].OptionsColumn.ReadOnly = true;
            }
            gridView2.OptionsView.ColumnAutoWidth = false;
            //gridView2.Columns["SanPhamID"].OptionsColumn.ReadOnly = true;
        }
        private void frmDonHang_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            gridControl1.DataSource = DonHangController.GetListInWeek();//lay danh sach don hang trong tuan
            txtSearchDonHang.Properties.NullValuePrompt = "nhập mã đơn hàng/tên khách hàng/số điện thoại để tìm kiếm";
            //TextEdit.Properties.NullValuePrompt

            dateEditStart.DateTime = DateTime.Now;
            dateEditEnd.DateTime = dateEditStart.DateTime;
        }

        private void gr_btn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int intRow = gridView1.FocusedRowHandle;
            if ((intRow>=0)&&(gridView1.GetRowCellValue(intRow,"DonHangID")!=null))
            {
                string strDonHangID = gridView1.GetRowCellValue(intRow, "DonHangID").ToString();
                switch (e.Button.Caption.ToUpper())
                {
                    case "PRINT":
                        PhieuBanHang rp = new PhieuBanHang();                        
                        rp.SetDataSource(reportsController.prtDonHang(strDonHangID));                        
                        rp.Refresh();
                        ThongTinShop shop = ThongTinShopController.GetItem();
                        rp.SetParameterValue("TenShop", shop.TenShop);
                        rp.SetParameterValue("DiaChi", shop.DiaChi);
                        rp.SetParameterValue("SoDienThoai", shop.SoDienThoai);
                        rp.SetParameterValue("WebSite", shop.Website);
                        frmViewReports fReport =  null;
                        foreach (Form item in MdiChildren)
                        {
                            if (item.GetType()==typeof(frmViewReports))
                            {
                                fReport = (item as frmViewReports);                                
                                fReport.crystalReportViewer1.ReportSource = rp;                                
                                fReport.Activate();
                                return;
                            }
                        }
                        fReport = new frmViewReports();                        
                        fReport.crystalReportViewer1.ReportSource = rp;                       
                        fReport.MdiParent = this.MdiParent;
                        fReport.Show();
                        break;
                    case "DEL":
                        if(MessageBox.Show("Bạn muốn xóa đơn hàng này","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.Yes)
                        {
                            DonHangController.Del(strDonHangID);
                            gridControl1.DataSource = DonHangController.GetAllList();
                        }
                        break;
                    case "VIEW":		                
                        DonHang viewItem = DonHangController.GetItem(strDonHangID);
                        if (viewItem!=null)
	                    {
                            frmAddDonHang f = new frmAddDonHang();
                            f.ViewItem = viewItem;
                            f.forMode = "view";
                            f.MdiParent = this.MdiParent;
                            f.Show();
                            this.Dispose();
	                    }
                        break;
                    default:
                        break;
                }
            }
        }

        private void txtSearchDonHang_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.ActiveFilterString = string.Format("[DonHangID] like '%{0}%' or [TenKhachHang] like '%{0}%' or [SoDienThoai] like '%{0}%'", txtSearchDonHang.Text);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = DonHangController.GetListRangDate(dateEditStart.DateTime, dateEditEnd.DateTime);
            gridView1.BestFitColumns();
        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            DateTime dtMonday = DateTime.Today;
            int offset = dtMonday.DayOfWeek - DayOfWeek.Monday;
            dtMonday = dtMonday.AddDays(0 - offset);
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridControl2.DataSource = null;
            int intSelectRow = gridView1.FocusedRowHandle;
            if ((intSelectRow >= 0) && (intSelectRow < gridView1.RowCount))
            {
                string strDonHangID = gridView1.GetRowCellValue(intSelectRow, "DonHangID").ToString();
                gridControl2.DataSource= DonHangController.GetSanPham(strDonHangID);
                gridView2.BestFitColumns();
            }
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
    }
}
