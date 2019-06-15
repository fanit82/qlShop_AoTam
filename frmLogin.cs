using qlShop.models;
using qlShop.qlshop_model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;

namespace qlShop
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void DangNhap()
        {
            NguoiDung item = new NguoiDung();
            item = NguoiDungController.ChungThuc(txtTenDangNhap.Text.Trim(), txtMatKhau.Text.Trim());
            if (item==null)
            {
                MessageBox.Show("Chứng thực lỗi, vui lòng kiểm tra lại tên và mật khẩu");
                txtTenDangNhap.Focus();
                txtTenDangNhap.SelectAll();
                return;
            }
            else
            {
                Utility.NguoiSuDung = item;
                frmMain f = new frmMain();
                f.Show();
                this.Hide();
                //this.Close();
            }
            //item = 
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            //kiem tra ket noi database
            try
            {
                Utility.isConect();
                DangNhap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối database lỗi, xin kiểm tra lại kết nối \n\n" + ex.Message);
                return;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void pictureEdit1_DoubleClick(object sender, EventArgs e)
        {
            frmConfigDatabase f = new frmConfigDatabase();
            //frmConfigDatabase2 f = new frmConfigDatabase2();
            if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                LayThongTinKetNoiCSDL();
            }                       
        }

        public void LayThongTinKetNoiCSDL()
        {
            DataSet DsXML = new DataSet();
            string strPathFile = Application.StartupPath + "/configapp.xml";
            lbKetNoi.Text = "Chưa cấu hình có kết nối CSDL";
            DataSet dsXML = new DataSet();
            if (System.IO.File.Exists(strPathFile))
            {
                DsXML.ReadXml(strPathFile);
                if (DsXML.Tables[0] != null)
                {
                    DataTable tblXML = DsXML.Tables[0];
                    if (tblXML.Rows.Count > 0)
                    {
                        foreach (DataRow item in DsXML.Tables[0].Rows)
                        {
                            if (Convert.ToBoolean(item["Default"].ToString()))
                            {
                                //SqlConnectionStringBuilder sqlcnnbuild = new SqlConnectionStringBuilder();
                                //sqlcnnbuild.DataSource = item["Server_name"].ToString();
                                //sqlcnnbuild.InitialCatalog = item["database_name"].ToString();
                                //sqlcnnbuild.IntegratedSecurity = Convert.ToBoolean(item["windows_Auth"].ToString());
                                //sqlcnnbuild.UserID = item["user_name"].ToString();
                                //sqlcnnbuild.Password = item["password"].ToString();
                                string connectionString = string.Format("Data Source={0};" +
                                    "Initial Catalog={1};" +
                                    "Integrated Security={2};" +
                                    "User ID={3};" +
                                    "Password={4};" +
                                    "MultipleActiveResultSets=True;" +
                                    "App=EntityFramework",
                                    item["Server_name"].ToString(),
                                    item["database_name"].ToString(),
                                    Convert.ToBoolean(item["windows_Auth"].ToString()),
                                    item["user_name"].ToString(),
                                    item["password"].ToString());
                                lbKetNoi.Text = "Đang kết nối CSDL: " + item["Connect_name"].ToString();
                                Utility.strConnectString = connectionString;
                                Utility.TenKetNoi = item["Connect_name"].ToString();
                                //save kết nối vô appconfig
                                new AppSetting().SaveConnectionString(Utility.KeyConnectString, connectionString);
                                //sqlcnn.ConnectionString = sqlcnnbuild.ConnectionString;
                            }
                        }
                    }
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            LayThongTinKetNoiCSDL();
            groupControl1.Text =string.Format("Hệ thống quản lý bán hàng - Phiên bản : {0} - cập nhật 03/06/2019",
                Assembly.GetExecutingAssembly().GetName().Version.ToString());           
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                btnOk.PerformClick();
            }
        }
    }
}
