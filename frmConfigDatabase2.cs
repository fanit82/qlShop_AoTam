using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace qlShop
{
    public partial class frmConfigDatabase2 : Form
    {
        //Tên chuổi kết nối trong app.config , tên nay liên quan đến kết nối EF - không thây đổi tên nay
        //string strKeyCnn = "qlshopConn"; 
        public frmConfigDatabase2()
        {
            InitializeComponent();
        }
        private void frmConfigDatabase2_Load(object sender, EventArgs e)
        {
            //Add server name to combobox            

            cboServer.Properties.Items.Add(".");
            cboServer.Properties.Items.Add("(local)");
            cboServer.Properties.Items.Add(@".\SQLEXPRESS");
            cboServer.Properties.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            cboServer.SelectedIndex = 3;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Set connection string
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};MultipleActiveResultSets=True;App=EntityFramework", cboServer.Text, txtDatabase.Text, txtUsername.Text, txtPassword.Text);
            //SqlHelper helper = new SqlHelper();
            //SqlHelper.
            SqlConnection sqlcnn = new SqlConnection();
            sqlcnn.ConnectionString = connectionString;
            try
            {
                sqlcnn.Open();
                MessageBox.Show("Kết nối thành công");
                sqlcnn.Close();
                AppSetting setting = new AppSetting();
                setting.SaveConnectionString(qlShop.models.Utility.KeyConnectString, connectionString);
                //sqlcnn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
                return;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string strConnect = new AppSetting().GetConnectionString(qlShop.models.Utility.KeyConnectString);
            if ((strConnect is null)||(strConnect == string.Empty))
            {
                MessageBox.Show("Chưa cấu hình chuổi kết nối trong hệ thống");
                return;
            }
            else
            {
                SqlConnection sqlcnn = new SqlConnection();                
                sqlcnn.ConnectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};MultipleActiveResultSets=True;App=EntityFramework", cboServer.Text, txtDatabase.Text, txtUsername.Text, txtPassword.Text);
                try
                {
                    sqlcnn.Open();
                    MessageBox.Show("Kết nối thành công");
                    sqlcnn.Close();
                    //sqlcnn.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                    return;
                }
            }
        }
    }   
}