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
    public partial class frmChangePass : Form
    {
        public frmChangePass()
        {
            InitializeComponent();
        }

        private void frmChangePass_Load(object sender, EventArgs e)
        {
            txtPassOld.Properties.PasswordChar = '*';
            txtPassNew.Properties.PasswordChar = '*';
            txtPassNew2.Properties.PasswordChar = '*';
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!Utility.NguoiSuDung.MatKhau.Equals(txtPassOld.Text.Trim()))
            {
                MessageBox.Show("Mật khẩu cũ không đúng, xin kiểm tra lại");
                return;
            }
            else
            {
                if (!txtPassNew.Text.Trim().Equals(txtPassNew2.Text.Trim()))
                {
                    MessageBox.Show("Mật khẩu mới nhập lần 1 và 2 không tương thích, xin nhập lại ");
                    txtPassNew2.SelectAll();
                    return;
                }
                else
                {
                    NguoiDungController.DoiPass(Utility.NguoiSuDung.NguoiDungID, txtPassNew2.Text.Trim());
                    MessageBox.Show("Đã thay đổi mật khẩu mới, lưu ý cho lần đăng nhập tiếp theo");
                    this.Close();
                }
            }
        }
    }
}
