using qlShop.models;
using qlShop.qlshop_model;
using System;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            gridControl1.DataSource = KhachHangController.GetList();
        }
        private void KhoiTaoLuoi()
        {
            int i = 0;
            gridView1.Columns[i].Caption = "Khách hàng";
            gridView1.Columns[i].FieldName = "KhachHangID";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            i++;
            gridView1.Columns[i].Caption = "Tên khách hàng";
            gridView1.Columns[i].FieldName = "TenKhachHang";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Số đt";
            gridView1.Columns[i].FieldName = "SoDienThoai";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Sinh nhật";
            gridView1.Columns[i].FieldName = "SinhNhat";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Tổng tiền hàng";
            gridView1.Columns[i].FieldName = "TongTienHang";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ### ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Công Nợ";
            gridView1.Columns[i].FieldName = "CongNo";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ### ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Ghi chú";
            gridView1.Columns[i].FieldName = "GhiChu";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            gridView1.Columns[i].Visible = false;

            i++;
            gridView1.Columns[i].Caption = "#";
            gridView1.Columns[i].OptionsColumn.FixedWidth = true;
            gridView1.Columns[i].Width = 50;
            //gridView1.ActiveFilterString = "[NgungKinhDoanh]=false";
            gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;

            //gr_btn_del.Buttons[1].Visible = false;//Ẩn nút kinh doanh lại - vì mặc định đang hiển thị các sp kinh doanh
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddKhachHang f = new frmAddKhachHang();
            f.ShowDialog(this);
            gridControl1.DataSource = KhachHangController.GetList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int intRow = gridView1.FocusedRowHandle;
            if (intRow>=0)
            {
                string strKhachHangID = gridView1.GetRowCellValue(intRow, "KhachHangID").ToString();
                KhachHang item = KhachHangController.GetItem(strKhachHangID);
                if (item!=null)
                {
                    frmAddKhachHang f = new frmAddKhachHang();
                    f.frmMode = "edit";
                    f.EditItem = item;
                    f.ShowDialog(this);
                    gridControl1.DataSource = KhachHangController.GetList();
                    gridView1.FocusedRowHandle = intRow;
                }
            }
        }

        private void gr_btn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption.ToUpper().Equals("DEL"))//nguoi dung xóa
            {
                int intRow = gridView1.FocusedRowHandle;
                if (intRow>=0)
                {
                    string strKhachHangID = gridView1.GetRowCellValue(intRow, "KhachHangID").ToString();
                    if( MessageBox.Show("Bạn muốn xóa khách hàng này??","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.Yes)
                    {
                        KhachHangController.DelItem(strKhachHangID);
                        gridControl1.DataSource = KhachHangController.GetList();
                    }

                }
            }
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
    }
}
