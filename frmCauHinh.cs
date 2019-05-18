using qlShop.models;
using System;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmCauHinh : Form
    {
        string strMode = "View";
        public frmCauHinh()
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

        private void frmCauHinh_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            gridControl1.DataSource = NguoiDungController.GetList();
            setTrangThaiNut();
            //
            LayThongTinShop();
            // load roles
            cbbRoles.Properties.Items.Add(Utility.QUANLY);
            cbbRoles.Properties.Items.Add(Utility.NHANVIEN);
        }
        private void GhiThongTinNGuoiDung()
        {
            NguoiDung itemNguoiDung = new NguoiDung();
            itemNguoiDung.NguoiDungID = txtNguoiDungID.Text.Trim();
            itemNguoiDung.MatKhau = txtMatKhau.Text.Trim();
            itemNguoiDung.TenNguoiDung = txtTenNguoiDung.Text.Trim();
            itemNguoiDung.Roles = cbbRoles.EditValue.ToString();
            if (strMode.ToUpper().Equals("ADD"))
            {
                NguoiDungController.Add(itemNguoiDung);    
            }
            else
            {
                if (strMode.ToUpper().Equals("EDIT"))
                {
                    NguoiDungController.Edit(itemNguoiDung);
                }
            }            
            gridControl1.DataSource = NguoiDungController.GetList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtNguoiDungID.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
            txtTenNguoiDung.Text = string.Empty;
            cbbRoles.SelectedIndex = 0;
            strMode = "add";
            setTrangThaiNut();
            //ThemNguoiDung();
            //MessageBox.Show("Đã thêm user thành công");

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GhiThongTinNGuoiDung();
            strMode = "view";
            setTrangThaiNut();
            //if (strMode.ToUpper().Equals("ADD"))
            //{
            //    ThemNguoiDung();
            //    MessageBox.Show("Đã thêm user thành công");
            //    strMode = "view";
            //    setTrangThaiNut();
            //}            
        }
        private void setTrangThaiNut()
        {
            switch (strMode.ToUpper())
            {
                case "VIEW":
                    btnEdit.Enabled = true;
                    btnAdd.Enabled = true;
                    btnSave.Enabled = false;
                    txtNguoiDungID.Enabled = false;
                    txtMatKhau.Enabled = false;
                    txtTenNguoiDung.Enabled = false;
                    cbbRoles.Enabled = false;
                    break;
                case "ADD":
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnSave.Enabled = true;
                    txtNguoiDungID.Enabled = true;
                    txtMatKhau.Enabled = true;
                    txtTenNguoiDung.Enabled = true;
                    cbbRoles.Enabled = true;
                    break;
                case "EDIT":
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnSave.Enabled = true;
                    txtNguoiDungID.Enabled = true;
                    txtMatKhau.Enabled = true;
                    txtTenNguoiDung.Enabled = true;
                    cbbRoles.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int introw = gridView1.FocusedRowHandle;
            string strNguoiDungID = string.Empty;
            if (introw >= 0)
            {
                strNguoiDungID = gridView1.GetRowCellValue(introw, "NguoiDungID").ToString();
            }
            if (strNguoiDungID != string.Empty)
            {
                NguoiDung selectUser = NguoiDungController.GetItem(strNguoiDungID);
                if (selectUser != null)
                {
                    txtNguoiDungID.Text = selectUser.NguoiDungID;
                    txtMatKhau.Text = selectUser.MatKhau;
                    txtTenNguoiDung.Text = selectUser.TenNguoiDung;
                    cbbRoles.EditValue = selectUser.Roles == null ? null : selectUser.Roles;
                    //strMode = "edit";
                    //setTrangThaiNut();
                }
            }
        }

        private void gr_btn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption.ToUpper().Equals("DELETE"))
            {
                int introw = gridView1.FocusedRowHandle;
                string strNguoiDungID = string.Empty;
                if (introw >= 0)
                {
                    strNguoiDungID = gridView1.GetRowCellValue(introw, "NguoiDungID").ToString();
                }
                if ((strNguoiDungID != string.Empty)&&(!strNguoiDungID.ToUpper().Equals("ADMIN")))
                {
                    if(MessageBox.Show("Bạn muốn xóa người sử dụng này?","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        NguoiDungController.Del(strNguoiDungID);
                        gridControl1.DataSource = NguoiDungController.GetList();
                        //if ((gridView1.RowCount>introw )&&(introw>0))
                        //{
                        //    gridView1.FocusedRowHandle = introw - 1;
                        //}
                    }
                }
                else
                {
                    if (strNguoiDungID.ToUpper().Equals("ADMIN"))
                    {
                        MessageBox.Show("Không được xóa user ADMIN","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            strMode = "EDIT";
            setTrangThaiNut();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            strMode = "view";
            setTrangThaiNut();
        }

        //--------------------------------------------------
        private void LayThongTinShop()
        {
            ThongTinShop iThongtinShop = new ThongTinShop();
            iThongtinShop = ThongTinShopController.GetItem();
            if (iThongtinShop!=null)
            {
                txtTenShop.Text = iThongtinShop.TenShop;
                txtDiaChi.Text = iThongtinShop.DiaChi;
                txtSoDienThoai.Text = iThongtinShop.SoDienThoai;
                txtwebsite.Text = iThongtinShop.Website;
            }
        }

        private void btnsaveThongTinShop_Click(object sender, EventArgs e)
        {
            ThongTinShop iThongtinShop = new ThongTinShop();
            iThongtinShop.TenShop = txtTenShop.Text;
            iThongtinShop.DiaChi= txtDiaChi.Text;
            iThongtinShop.SoDienThoai= txtSoDienThoai.Text;
            iThongtinShop.Website=txtwebsite.Text;
            ThongTinShopController.Update(iThongtinShop);
            MessageBox.Show("Đã cập nhật thông tin shop","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);            
        }
    }
}
