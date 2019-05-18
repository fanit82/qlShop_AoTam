using System.Windows.Forms;
using qlShop.models;
namespace qlShop
{
    public partial class frmTimSanPham : Form
    {

        //khai bao delegate
        public delegate void SendData(string strData);
        public SendData SendSanPhamID;
        public frmTimSanPham()
        {
            InitializeComponent();
        }

        private void KhoiTaoLuoi()
        {
            int i = 0;
            gridView1.Columns[i].Caption = "Sản phẩm";
            gridView1.Columns[i].FieldName = "TenSanPham";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            i++;
            gridView1.Columns[i].Caption = "Mã sản phẩm";
            gridView1.Columns[i].FieldName = "SanPhamID";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Nhóm sản phẩm";
            gridView1.Columns[i].FieldName = "TenNhomHang";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Giá bán";
            gridView1.Columns[i].FieldName = "GiaBan";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ### ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Tồn kho";
            gridView1.Columns[i].FieldName = "SLTonKho";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Nhà sản xuất";
            gridView1.Columns[i].FieldName = "TenNhaSanXuat";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Mã sản phẩm";
            gridView1.Columns[i].FieldName = "SanPhamID";
            gridView1.Columns[i].Visible = false;
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "#";
            //gridView1.Columns[i].Name = "CHUC_NANG";
            gridView1.Columns[i].OptionsColumn.FixedWidth = true;
            gridView1.Columns[i].Width = 70;
            //kiểm tra nếu nhân viên thì ẩn chức năng thao tác
        }


        private void frmTimSanPham_Load(object sender, System.EventArgs e)
        {
            KhoiTaoLuoi();
            gridControl1.DataSource = SanPhamController.GetAllList();
        }

        private void txtSearch_EditValueChanged(object sender, System.EventArgs e)
        {
            gridView1.ActiveFilterString = string.Format("[SanPhamID] like '%{0}%' or TenSanPham like '%{0}%'", txtSearch.Text);
        }

        private void gr_btn_del_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int i = gridView1.FocusedRowHandle;
            if( e.Button.Caption.ToUpper().Equals("CHON"))
            {
                string strSanPhamID = gridView1.GetRowCellValue(i, "SanPhamID").ToString();
                SendSanPhamID(strSanPhamID);
            }
        }
    }
}
