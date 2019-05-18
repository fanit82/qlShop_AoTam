using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using qlShop.models;
namespace qlShop
{
    public partial class frmTraCuuThongTin : Form
    {
        public frmTraCuuThongTin()
        {
            InitializeComponent();
        }


        private void InitGrid()
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
            gridView1.Columns[i].Caption = "Số chứng từ";
            gridView1.Columns[i].FieldName = "DonHangID";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;


            i++;
            gridView1.Columns[i].Caption = "Khách hàng";
            gridView1.Columns[i].FieldName = "TenKhachHang";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Số đt";
            gridView1.Columns[i].FieldName = "SoDienThoai";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Mã";
            gridView1.Columns[i].FieldName = "SanPhamID";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Sản Phẩm";
            gridView1.Columns[i].FieldName = "TenSanPham";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Số lượng";
            gridView1.Columns[i].FieldName = "SoLuong";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Đơn giá";
            gridView1.Columns[i].FieldName = "DonGia";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
           
            i++;
            gridView1.Columns[i].Caption = "Thành tiền";
            //gridView1.Columns[i].FieldName = "TongTienTra";
            gridView1.Columns[i].UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            gridView1.Columns[i].UnboundExpression = "[SoLuong]*[DonGia]";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Nhân viên";
            gridView1.Columns[i].FieldName = "TenNhanVien";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            gridView1.OptionsView.ColumnAutoWidth = false;                
        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            DateTime dtMonday = DateTime.Today;
            int offset = dtMonday.DayOfWeek - DayOfWeek.Monday;
            dtMonday = dtMonday.AddDays(0 - offset);
            dateEditStart.EditValue = dtMonday;
            dateEditEnd.EditValue = dtMonday.AddDays(6);
            simpleButton4.PerformClick();
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            DateTime dtToday = DateTime.Today;
            dtToday = new DateTime(dtToday.Year, dtToday.Month, 1);
            dateEditStart.EditValue = dtToday;
            dateEditEnd.EditValue = dtToday.AddMonths(1).AddDays(-1);
            simpleButton4.PerformClick();
        }
        private void btnYear_Click(object sender, EventArgs e)
        {
            DateTime dtToday = DateTime.Today;
            dtToday = new DateTime(dtToday.Year, 1, 1);
            dateEditStart.EditValue = dtToday;
            dateEditEnd.EditValue = dtToday.AddYears(1).AddDays(-1);
            simpleButton4.PerformClick();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            DataTable TblData = DonHangController.TraCuuChiTietDonHang(dateEditStart.DateTime, dateEditEnd.DateTime);
            gridControl1.DataSource = TblData;
            gridView1.BestFitColumns();
        }
        private void frmTraCuuThongTin_Load(object sender, EventArgs e)
        {
            //gridControl1.DataSource = DonHangController.GetListInWeek();//lay danh sach don hang trong tuan
            txtSearchDonHang.Properties.NullValuePrompt = "nhập mã đơn hàng/tên khách hàng/số điện thoại/MÃ sản phẩm/ Tên sản phẩm để tìm kiếm";
            //TextEdit.Properties.NullValuePrompt
            dateEditStart.DateTime = DateTime.Now;
            dateEditEnd.DateTime = dateEditStart.DateTime;
            InitGrid();
        }

        private void txtSearchDonHang_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.ActiveFilterString = string.Format("[DonHangID] like '%{0}%' or [TenKhachHang] like '%{0}%' or [SoDienThoai] like '%{0}%' or SanPhamID like '%{0}%' or TenSanPham like'%{0}%'", txtSearchDonHang.Text);
        }
    }
}
