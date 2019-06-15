using qlShop.models;
using qlShop.qlshop_model;
using System;
using System.Data;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmNhapKho : Form
    {
        public frmNhapKho()
        {
            InitializeComponent();
        }

        private void KhoiTaoLuoi()
        {
            int i = 0;
            gridView1.Columns[i].Caption = "Ngày nhập";
            gridView1.Columns[i].FieldName = "NgayNhap";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns[i].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;


            i++;
            gridView1.Columns[i].Caption = "Phiếu nhập";
            gridView1.Columns[i].FieldName = "PhieuNhapID";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Nhà cung cấp";
            gridView1.Columns[i].FieldName = "TenNhaCungCap";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            gridView1.Columns[i].BestFit();

            i++;
            gridView1.Columns[i].Caption = "Tiền hàng";
            gridView1.Columns[i].FieldName = "TienHang";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            gridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[i].SummaryItem.DisplayFormat = "{0:### ### ### ###}";

            i++;
            gridView1.Columns[i].Caption = "Thanh toán";
            gridView1.Columns[i].FieldName = "ThanhToan";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            gridView1.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns[i].SummaryItem.DisplayFormat = "{0:### ### ### ###}";

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

            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.IndicatorWidth = 30;
            gridView1.OptionsView.ShowFooter = true;
            //for (int j = 0; j < gridView1.RowCount; j++)
            //{
            //    gridView1.Columns[j].OptionsColumn.AllowEdit = false;
            //}

            //Gridview2
            i = 0;

            gridView2.Columns[i].Caption = "Sản phẩm";
            gridView2.Columns[i].FieldName = "SanPhamID";
            gridView2.Columns[i].GroupIndex = 1;

            i++;
            gridView2.Columns[i].Caption = "Tên Sản phẩm";
            gridView2.Columns[i].FieldName = "TenSanPham";
            //gridView2.Columns[i].GroupIndex = 1;

            i++;
            gridView2.Columns[i].Caption = "Size";
            gridView2.Columns[i].FieldName = "Size";

            i++;
            gridView2.Columns[i].Caption = "Số lượng";
            gridView2.Columns[i].FieldName = "SoLuong";
            gridView2.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns[i].SummaryItem.DisplayFormat = "{0:### ### ### ###}";

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
            gridView2.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView2.Columns[i].SummaryItem.DisplayFormat = "{0:### ### ### ###}";
            for (int k = 0; k < gridView2.Columns.Count; k++)
            {
                gridView2.Columns[k].OptionsColumn.ReadOnly = true;
            }
            gridView2.OptionsView.ColumnAutoWidth = false;
            gridView2.IndicatorWidth = 30;
            gridView2.OptionsView.ShowFooter = true;
        }

        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            dateEditStart.DateTime = DateTime.Now;
            dateEditEnd.DateTime = dateEditStart.DateTime;
            //DataView ViewPhieuNhap = PhieuNhapController.GetAllList().DefaultView;
            //ViewPhieuNhap.Sort = "[NgayNhap] DESC";
            //gridControl1.DataSource = ViewPhieuNhap;
            //gridView1.BestFitColumns();
            btnFind.PerformClick();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddPhieuNhap f = new frmAddPhieuNhap();
            f.MdiParent = this.MdiParent;
            f.Show();
            this.Dispose();
        }

        private void gr_btn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int intRow = gridView1.FocusedRowHandle;
            if ((intRow >= 0) && (gridView1.GetRowCellValue(intRow, "PhieuNhapID") != null))
            {
                string strPhieuNhap = gridView1.GetRowCellValue(intRow, "PhieuNhapID").ToString();
                switch (e.Button.Caption.ToUpper())
                {
                    //case "PRINT":
                    //    PhieuBanHang rp = new PhieuBanHang();
                    //    rp.SetDataSource(reportsController.prtDonHang(strDonHangID));
                    //    rp.Refresh();
                    //    ThongTinShop shop = ThongTinShopController.GetItem();
                    //    rp.SetParameterValue("TenShop", shop.TenShop);
                    //    rp.SetParameterValue("DiaChi", shop.DiaChi);
                    //    rp.SetParameterValue("SoDienThoai", shop.SoDienThoai);
                    //    rp.SetParameterValue("WebSite", shop.Website);
                    //    frmViewReports fReport = null;
                    //    foreach (Form item in MdiChildren)
                    //    {
                    //        if (item.GetType() == typeof(frmViewReports))
                    //        {
                    //            fReport = (item as frmViewReports);
                    //            fReport.crystalReportViewer1.ReportSource = rp;
                    //            fReport.Activate();
                    //            return;
                    //        }
                    //    }
                    //    fReport = new frmViewReports();
                    //    fReport.crystalReportViewer1.ReportSource = rp;
                    //    fReport.MdiParent = this.MdiParent;
                    //    fReport.Show();
                    //    break;
                    case "DEL":
                        if (MessageBox.Show("Bạn muốn xóa đơn hàng này", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            PhieuNhapController.Del(strPhieuNhap);
                            gridControl1.DataSource = PhieuNhapController.GetAllList();
                        }
                        break;
                    case "VIEW":
                        PhieuNhap viewItem = PhieuNhapController.GetItem(strPhieuNhap);
                        if (viewItem != null)
                        {
                            frmAddPhieuNhap f = new frmAddPhieuNhap();
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridControl2.DataSource = null;
            int intSelectRow = gridView1.FocusedRowHandle;
            if ((intSelectRow >= 0) && (intSelectRow < gridView1.RowCount))
            {
                string strDonHangID = gridView1.GetRowCellValue(intSelectRow, "PhieuNhapID").ToString();
                gridControl2.DataSource = PhieuNhapController.GetSanPham(strDonHangID); //DonHangController.GetSanPham(strDonHangID);                
                gridView2.ExpandAllGroups();
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

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void btnFind_Click(object sender, EventArgs e)
        {
            DataView tblDefaultView = PhieuNhapController.GetListRangDate(dateEditStart.DateTime, dateEditEnd.DateTime).DefaultView;
            tblDefaultView.Sort = "[NgayNhap] DESC";
            gridControl1.DataSource = tblDefaultView;
            gridView1.BestFitColumns();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DateTime dtMonday = DateTime.Today;
            int offset = dtMonday.DayOfWeek - DayOfWeek.Monday;
            dtMonday = dtMonday.AddDays(0 - offset);
            dateEditStart.EditValue = dtMonday;
            dateEditEnd.EditValue = dtMonday.AddDays(6);
            btnFind.PerformClick();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DateTime dtToday = DateTime.Today;
            dtToday = new DateTime(dtToday.Year, dtToday.Month, 1);
            dateEditStart.EditValue = dtToday;
            dateEditEnd.EditValue = dtToday.AddMonths(1).AddDays(-1);
            btnFind.PerformClick();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DateTime dtToday = DateTime.Today;
            dtToday = new DateTime(dtToday.Year, 1, 1);
            dateEditStart.EditValue = dtToday;
            dateEditEnd.EditValue = dtToday.AddYears(1).AddDays(-1);
            btnFind.PerformClick();
        }
    }
}
