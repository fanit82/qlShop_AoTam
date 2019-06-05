using qlShop.models;
using qlShop.qlshop_model;
using System;
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
            gridView1.Columns[i].DisplayFormat.FormatString = "# ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Thanh toán";
            gridView1.Columns[i].FieldName = "ThanhToan";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "# ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Nợ";
            gridView1.Columns[i].FieldName = "ConNo";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "# ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Nhân viên";
            gridView1.Columns[i].FieldName = "TenNhanVien";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "#";
            gridView1.Columns[i].OptionsColumn.FixedWidth = true;
            gridView1.Columns[i].Width = 70;

            //for (int j = 0; j < gridView1.RowCount; j++)
            //{
            //    gridView1.Columns[j].OptionsColumn.AllowEdit = false;
            //}
        }

        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            gridControl1.DataSource = PhieuNhapController.GetAllList();
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
    }
}
