using qlShop.models;
using System;
using System.Windows.Forms;

namespace qlShop
{
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        private void KhoiTaoLuoi()
        {
            int i = 0;
            gridView1.Columns[i].Caption = "Nhà cung cấp";
            gridView1.Columns[i].FieldName = "NhaCungCapID";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            i++;
            gridView1.Columns[i].Caption = "Tên nhà cung cấp";
            gridView1.Columns[i].FieldName = "TenNhaCungCap";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Số đt";
            gridView1.Columns[i].FieldName = "SoDienThoai";
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

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            gridControl1.DataSource = NhaCungCapControlller.GetList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddNhaCungCap f = new frmAddNhaCungCap();
            f.ShowDialog(this);
            gridControl1.DataSource = NhaCungCapControlller.GetList();
        }

        private void gr_btn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int intRow = gridView1.FocusedRowHandle;
            string strNhaCungCapID = gridView1.GetRowCellValue(intRow, "NhaCungCapID").ToString();
            if ((e.Button.Caption.ToUpper().Equals("DEL"))&&(strNhaCungCapID!=string.Empty))
            {
                if(MessageBox.Show("Bạn muốn xóa nhà cung cấp này không","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.Yes)
                {
                    NhaCungCapControlller.DelItem(strNhaCungCapID);
                    gridControl1.DataSource = NhaCungCapControlller.GetList();
                }                
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int intRow = gridView1.FocusedRowHandle;
            if (intRow >= 0)
            {
                string strNhaCungCapID = gridView1.GetRowCellValue(intRow, "NhaCungCapID").ToString();
                NhaCungCap item = NhaCungCapControlller.GetItem(strNhaCungCapID);
                if (item != null)
                {
                    frmAddNhaCungCap f = new frmAddNhaCungCap();
                    f.frmMode = "edit";
                    f.EditItem = item;
                    if (f.ShowDialog(this)== System.Windows.Forms.DialogResult.OK)
                    {
                        gridControl1.DataSource = NhaCungCapControlller.GetList();
                        gridView1.FocusedRowHandle = intRow;
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
