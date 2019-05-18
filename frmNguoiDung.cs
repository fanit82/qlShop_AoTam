using qlShop.models;
using System;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmNguoiDung : Form
    {
        public frmNguoiDung()
        {
            InitializeComponent();
        }

        private void KhoiTaoLuoi()
        {
            int i = 0;
            gridView1.Columns[i].Caption = "Tên truy cập";
            gridView1.Columns[i].FieldName = "NguoiDungID";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            i++;
            gridView1.Columns[i].Caption = "Tên";
            gridView1.Columns[i].FieldName = "TenNguoiDung";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Quyền truy cập";
            gridView1.Columns[i].FieldName = "Roles";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Ngày tạo";
            gridView1.Columns[i].FieldName = "CreateDate";
            
            i++;
            gridView1.Columns[i].Caption = "#";
            gridView1.Columns[i].OptionsColumn.FixedWidth = true;
            gridView1.Columns[i].Width = 70;
            
            gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
        }

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            gridControl1.DataSource = NguoiDungController.GetList();
        }

    }
}
