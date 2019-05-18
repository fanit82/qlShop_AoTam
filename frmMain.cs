using DevExpress.XtraBars.Alerter;
using DevExpress.XtraNavBar;
using qlShop.models;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmMain : Form
    {
        private int childFormNumber = 0;

        /// <summary>
        /// set trạng thai menu theo phân quyền
        /// </summary>
        private void SetMenuItem()
        {

            if (Utility.NguoiSuDung.Roles.ToUpper().Equals(Utility.QUANLY.ToUpper())) //user quản lý
            {
                foreach (NavBarItem item in navBarControl1.Items)
                {
                    item.Visible = true;
                }
            }
            else
            {
                if (Utility.NguoiSuDung.Roles.ToUpper().Equals(Utility.NHANVIEN.ToUpper())) //user nhân viên
                {
                    string strAllowForm = "frmSanPham;frmDonHang;frmKhachHang;frmQuyTienMat;frmQLChiPhi;frmGachNo;frmDSTraHang;frmDSPhieuGachNo;frmChiPhi;frmTraCuuThongTin";
                    foreach (NavBarItem item in navBarControl1.Items)
                    {
                        if ((item.Tag ==null)||(strAllowForm.IndexOf(item.Tag.ToString()) >= 0))
                        {
                            item.Visible = true;
                        }
                        else
                        {
                            item.Visible = false;
                        }                        
                    }                    
                }
            }
        }
        public frmMain()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //frmSanPham f = new frmSanPham();
            //f.MdiParent = this;
            //f.Show();
            CallForm(sender as NavBarItem,".::Sản phẩm");
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            CallForm(sender as NavBarItem, ".::Khách hàng");
            //frmKhachHang f = new frmKhachHang();
            //f.MdiParent = this;
            //f.Show();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            CallForm(sender as NavBarItem, ".::Đơn hàng");
            //foreach (Form item in MdiChildren)
            //{
            //    if (item.GetType()==typeof(frmDonHang))
            //    {
            //        item.Activate();
            //        return;
            //    }
            //}
            //frmDonHang f = new frmDonHang();
            //f.MdiParent = this;
            //f.Show();
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            CallForm(sender as NavBarItem, ".::Nhà cung cấp");
            //foreach (Form item in MdiChildren)
            //{
            //    if (item.GetType() == typeof(frmNhaCungCap))
            //    {
            //        item.Activate();
            //        return;
            //    }
            //}
            //frmNhaCungCap f = new frmNhaCungCap();
            //f.MdiParent = this;
            //f.Show();
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            CallForm(sender as NavBarItem, ".::Nhập kho hàng");
            //foreach (Form item in MdiChildren)
            //{
            //    if (item.GetType() == typeof(frmNhapKho))
            //    {
            //        item.Activate();
            //        return;
            //    }
            //}
            //frmNhapKho f = new frmNhapKho();
            //f.MdiParent = this;
            //f.Show();
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            CallForm(sender as NavBarItem, ".::Tồn kho");
            //foreach (Form item in MdiChildren)
            //{
            //    if (item.GetType() == typeof(frmTonKho))
            //    {
            //        item.Activate();
            //        return;
            //    }
            //}
            //frmTonKho f = new frmTonKho();
            //f.MdiParent = this;
            //f.Show();
        }


        private void CallForm(NavBarItem ItemClick,string strTitle)
        {

            Type formtype = Type.GetType("qlShop." + ItemClick.Tag);
            if (formtype==null)
            {
                MessageBox.Show("Chức năng không tồn tài, vui lòng liên hệ tác giả","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            Form f= Activator.CreateInstance(formtype) as Form;
            if (f==null)
            {
                MessageBox.Show("Chức năng không tồn tài, vui lòng liên hệ tác giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //kiem tra form chuan bi mở đã mở chưa
            foreach (var item in MdiChildren)
            {
                if (item.GetType() == formtype)
                {
                    item.Activate();
                    return;
                }
            }
            f.Text = strTitle;
            f.MdiParent = this;
            f.Show();

        }
        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            CallForm(sender as NavBarItem, ".::Chi phí");
            //string formName = (sender as NavBarItem).Tag.ToString();
            //Form form = (Form)Activator.CreateInstance(Type.GetType(formName));
            //foreach (Form item in MdiChildren)
            //{
            //    if (item.GetType() == typeof(frmQLChiPhi))
            //    {
            //        item.Activate();
            //        return;
            //    }
            //}
            //frmQLChiPhi f = new frmQLChiPhi();
            //f.MdiParent = this;
            //f.Show();
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            CallForm(sender as NavBarItem, ".::Doanh số");
            //foreach (Form item in MdiChildren)
            //{
            //    if (item.GetType() == typeof(frmDoanhSo))
            //    {
            //        item.Activate();
            //        return;
            //    }
            //}
            //frmDoanhSo f = new frmDoanhSo();
            //f.MdiParent = this;
            //f.Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            CallForm(sender as NavBarItem, ".:Cấu hình");
            //foreach (Form item in MdiChildren)
            //{
            //    if (item.GetType() == typeof(frmCauHinh))
            //    {
            //        item.Activate();
            //        return;
            //    }
            //}
            //frmCauHinh f = new frmCauHinh();
            //f.MdiParent = this;
            //f.Show();
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            CallForm(sender as NavBarItem, ".::Gạch nợ");
            //foreach (Form item in MdiChildren)
            //{
            //    if (item.GetType() == typeof(frmGachNo))
            //    {
            //        item.Activate();
            //        return;
            //    }
            //}
            //frmGachNo f = new frmGachNo();
            //f.MdiParent = this;
            //f.Show();
        }
        private void navBarItem8_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            CallForm(sender as NavBarItem, ".::Tổng hợp");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string strTitle =  string.Format("Quản lý bán hàng - Người dùng hiện tại {0} - đăng nhập vào lúc {1}- Dữ liệu đang thao tác {2}",
                Utility.NguoiSuDung.NguoiDungID, DateTime.Now, Utility.TenKetNoi
                );
            this.Text = strTitle;            
            //setmenu theo phân quyền
            try
            {
                SetMenuItem();
                ThongBaoSinhNhat();
            }
            catch (Exception ex)
            {
                throw ex;
                //MessageBox.Show("Chương trình bị lỗi " + ex.Message + "\n\r Vui long liện hệ tác giả", "Thông Báo");
                //throw            
            }            
        }

        private void ThongBaoSinhNhat()
        {
            StringBuilder strInfor = new StringBuilder();
            DataTable tb = KhachHangController.DanhSachSinhNhat();
            if ((tb==null)||(tb.Rows.Count<1))
            {
                return;
            }
            else
            {
                strInfor.Append("Hôm nay là sinh nhật khách hang ");
                foreach (DataRow item in tb.Rows)
                {

                    strInfor.Append(string.Format("{0} - {1}", item["TenKhachHang"].ToString(), item["SoDienThoai"].ToString()));
                    strInfor.Append("\n\r");
                }
                strInfor.Append("Nhớ gọi điện chúc mừng nhé ");
            }
            AlertInfo info = new AlertInfo("Thông báo", strInfor.ToString());
            alertControl1.Show(this, info);
        }

        private void navBarItem12_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            CallForm(sender as NavBarItem, ".::Quỹ tiền mặt");
        }

        private void navBarItem13_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            CallForm(sender as NavBarItem, ".::Trả hàng");
        }

        private void navBarItem14_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            CallForm(sender as NavBarItem, ".::Tra cứu thông tin đơn hàng");
        }

        private void navBarItem16_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình?","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation)== System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void navBarItem17_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            frmChangePass f = new frmChangePass();
            f.ShowDialog(this);            
        }

        private void navBarItem15_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng nhập lại phiên làm việc?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}
