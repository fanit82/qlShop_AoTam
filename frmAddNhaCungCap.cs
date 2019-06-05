using System;
using System.Windows.Forms;
using qlShop.models;
using qlShop.qlshop_model;

namespace qlShop
{
    public partial class frmAddNhaCungCap : Form
    {
        public NhaCungCap EditItem { set; get; }
        public string strNewNhaCungCapID = string.Empty;
        public string frmMode { set; get; }
        public frmAddNhaCungCap()
        {
            this.frmMode = string.Empty;
            InitializeComponent();
        }

        private void save()
        {
            NhaCungCap item = new NhaCungCap();
            item.TenNhaCungCap = txtTenNhaCungCap.Text;
            item.SoDienThoai = txtSoDienThoai.Text;
            item.DiaChi = txtDiaChi.Text;
            item.Email = txtEmail.Text;
            item.MST = txtMST.Text;
            item.NguoiLienHe = textNguoiLienHe.Text;
            if (txtNhaCungCapID.Text.Trim()==string.Empty)//người dùng khong nhập mã
            {
                item.NhaCungCapID = NhaCungCapControlller.TaoMaNhaCungCap("AB", 8);
            }
            else
            {
                item.NhaCungCapID = txtNhaCungCapID.Text;
            }

            if (this.frmMode.ToUpper().Equals("EDIT"))
            {
                NhaCungCapControlller.Edit(item);
                EditItem = null;
            }
            else
            {
                NhaCungCapControlller.Add(item);
                strNewNhaCungCapID = item.NhaCungCapID; //lấy mã khách hàng mới vừa được tạo để đưa về form gọi
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            save();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            save();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            if (checkEditLuuThongTin.Checked==false)
            {
                txtTenNhaCungCap.Text = string.Empty;
                txtSoDienThoai.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtMST.Text = string.Empty;
                txtNhaCungCapID.Text = string.Empty;
                txtGhiChu.Text = string.Empty;
            }
            txtTenNhaCungCap.Focus();
        }

        private void frmAddNhaCungCap_Load(object sender, EventArgs e)
        {
            if ((this.EditItem != null) && this.frmMode.ToUpper().Equals("EDIT")) //user edit or copy
            {
                txtNhaCungCapID.Text = EditItem.NhaCungCapID;
                txtTenNhaCungCap.Text = EditItem.TenNhaCungCap;
                txtSoDienThoai.Text = EditItem.SoDienThoai;
                txtEmail.Text = EditItem.Email;
                txtGhiChu.Text = EditItem.GhiChu;
                txtNhaCungCapID.Text = EditItem.NhaCungCapID;
                txtMST.Text = EditItem.MST;
                textNguoiLienHe.Text = EditItem.NguoiLienHe;
                //không cho chỉnh sửa các thoogn tin khi edit
                txtNhaCungCapID.Properties.ReadOnly = true;
            }
        }
    }
}
