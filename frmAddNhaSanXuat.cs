using qlShop.models;
using System;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmAddNhaSanXuat : Form
    {
        public int intNhaSanXuatID = -1;
        public frmAddNhaSanXuat()
        {
            InitializeComponent();
        }
        private void KhoiTaoLuoi()
        {
            gridView1.Columns[0].Caption = "Nhà Sản Xuất";
            gridView1.Columns[0].FieldName = "TenNhaSanXuat";
            gridView1.Columns[0].OptionsColumn.AllowEdit = false;

            gridView1.Columns[1].Caption = "Nhà Sản Xuất";
            gridView1.Columns[1].FieldName = "NhaSanXuatID";
            gridView1.Columns[1].OptionsColumn.AllowEdit = false;
        }

        private void frmAddNhaSanXuat_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            gridControl1.DataSource = NhaSanXuatController.GetList();
        }
        private void Save()
        {
            NhaSanXuat item = new NhaSanXuat();
            item.TenNhaSanXuat = txtTenNhaSanXuat.Text.Trim();
            item.NguoiDungID = Utility.NguoiSuDung.NguoiDungID;
            item.TenNguoiDung = Utility.NguoiSuDung.TenNguoiDung;
            item.LastUpdate = DateTime.Now;
            intNhaSanXuatID = NhaSanXuatController.Add(item);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Save();
            gridControl1.DataSource = NhaSanXuatController.GetList();
        }

        private void gr_btn_del_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int intRowHandel = gridView1.FocusedRowHandle;
            if (intRowHandel>=0)
            {
                if (e.Button.Caption.ToUpper().Equals("DEL"))
                {
                    if(MessageBox.Show("Bạn muốn xóa nhà sản xuất này?","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.Yes)
                    {
                        int intNhaSanXuatID =Int32.Parse( gridView1.GetRowCellValue(intRowHandel, "NhaSanXuatID").ToString());
                        NhaSanXuatController.Del(intNhaSanXuatID);
                        gridControl1.DataSource = NhaSanXuatController.GetList();
                    }

                }                
            }

        }
    }
}
