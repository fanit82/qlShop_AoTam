using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace qlShop
{
    public partial class frmConfigDatabase : Form
    {
        DataSet DsXML = new DataSet();
        public frmConfigDatabase()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //DataSet dsXML = new DataSet();
                      DsXML.Tables[0].PrimaryKey = new DataColumn[] { DsXML.Tables[0].Columns["Connect_name"] };
            DataRow SetRow = DsXML.Tables[0].Rows.Find(cbbConnect_name.Text);            
            if (SetRow==null)
            {
                DsXML.Tables[0].Rows.Add(DsXML.Tables[0].Rows.Count, cbbConnect_name.Text, txtServer_name.Text, txtDatabase_name.Text, chk_win.Checked, txtUser_name.Text, txtPassword.Text, true);    
            }
            else
            {
                SetRow["Server_name"] = txtServer_name.Text;
                SetRow["database_name"] = txtDatabase_name.Text;
                SetRow["windows_Auth"] = chk_win.Checked;
                SetRow["user_name"] = txtUser_name.Text;
                SetRow["password"] = txtPassword.Text;
                SetRow["Default"] = true;
            }
            //set thong tin kết nối hiện tại là mặc định để kết nối
            foreach (DataRow item in DsXML.Tables[0].Rows)
            {
                if (!item["Connect_name"].ToString().Equals(cbbConnect_name.Text))
                {
                    item["Default"] = false;
                }
            }
            //DsXML.Tables.Add(tblConn);
            string strPathFile = Application.StartupPath + "/configapp.xml";
            DsXML.WriteXml(strPathFile);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            //


            this.Close();
        }
        public void ReadXML()
        {
            //cbbConnect_name.Properties.Items.Clear();
            string strPathFile = Application.StartupPath + "/configapp.xml";
            //DataSet dsXML = new DataSet();
            if (System.IO.File.Exists(strPathFile))
            {
                DsXML.ReadXml(strPathFile);
            }            
            if (DsXML.Tables.Count < 1)
            {
                DataTable tblConn = new DataTable();
                tblConn.TableName = "ConnectDatabase";
                tblConn.Columns.Add("ID", typeof(int));
                tblConn.Columns.Add("Connect_name", typeof(string));
                tblConn.Columns.Add("Server_name", typeof(string));
                tblConn.Columns.Add("database_name", typeof(string));
                tblConn.Columns.Add("windows_Auth", typeof(bool));
                tblConn.Columns.Add("user_name", typeof(string));
                tblConn.Columns.Add("password", typeof(string));
                tblConn.Columns.Add("Default", typeof(bool));
                tblConn.PrimaryKey = new DataColumn[]{tblConn.Columns["Connect_name"]};
                    //tblConn.Columns["Connect_name"];
                DsXML.Tables.Add(tblConn);
            }
            DataTable tblXML = DsXML.Tables[0];
            if (tblXML.Rows.Count > 0)
            {
                cbbConnect_name.Text = tblXML.Rows[0]["Connect_name"].ToString();
                txtServer_name.Text = tblXML.Rows[0]["Server_name"].ToString();
                txtDatabase_name.Text = tblXML.Rows[0]["database_name"].ToString();
                chk_win.Checked = Convert.ToBoolean(tblXML.Rows[0]["windows_Auth"]);
                txtUser_name.Text = tblXML.Rows[0]["user_name"].ToString();
                txtPassword.Text = tblXML.Rows[0]["password"].ToString();
            }
            for (int i = 0; i < tblXML.Rows.Count; i++)
            {
                cbbConnect_name.Properties.Items.Add(tblXML.Rows[i]["Connect_name"].ToString());
                if (Convert.ToBoolean(tblXML.Rows[i]["Default"].ToString()))
                {
                    cbbConnect_name.Text = tblXML.Rows[i]["Connect_name"].ToString();
                }
            }
            //DsXML.Tables[0].Rows.Add(DsXML.Tables[0].Rows.Count, "Nhập tên", null, null, null, null, null, null);
            //txtConnect_name.Properties.DataSource = DsXML.Tables[0];
            //txtConnect_name.Properties.DisplayMember = "Connect_name";
            //txtConnect_name.Properties.ValueMember = "ID";            
        }        
        private void frmConfigDatabase_Load(object sender, EventArgs e)
        {
            //txtConnect_name.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            //txtConnect_name.Properties.NullValuePrompt = "Nhập tên kết nối";
            //txtConnect_name.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            ReadXML();
        }

        private void cbbConnect_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cbbConnect_name.SelectedIndex;
            DataTable tblXML = DsXML.Tables[0];
            if ((i>=0)&&(tblXML.Rows[i] !=null))
            {
                cbbConnect_name.Text = tblXML.Rows[i]["Connect_name"].ToString();
                txtServer_name.Text = tblXML.Rows[i]["Server_name"].ToString();
                txtDatabase_name.Text = tblXML.Rows[i]["database_name"].ToString();
                chk_win.Checked = Convert.ToBoolean(tblXML.Rows[i]["windows_Auth"]);
                txtUser_name.Text = tblXML.Rows[i]["user_name"].ToString();
                txtPassword.Text = tblXML.Rows[i]["password"].ToString();                
            }

        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcnn = new SqlConnection();
            SqlConnectionStringBuilder sqlcnnbuild = new SqlConnectionStringBuilder();
            sqlcnnbuild.DataSource = txtServer_name.Text;
            sqlcnnbuild.InitialCatalog = txtDatabase_name.Text;
            sqlcnnbuild.IntegratedSecurity = chk_win.Checked;
            sqlcnnbuild.UserID = txtUser_name.Text;
            sqlcnnbuild.Password = txtPassword.Text;
            sqlcnn.ConnectionString = sqlcnnbuild.ConnectionString;
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

        private void cbbConnect_name_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if( e.Button.Caption.ToUpper() =="DELETE")
            {
                if (MessageBox.Show("Có muốn xóa cấu hình này không","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    int i = cbbConnect_name.SelectedIndex;
                    DataTable tblXML = DsXML.Tables[0];
                    tblXML.Rows.RemoveAt(i);
                    //ReadXML();
                    cbbConnect_name.Properties.Items.RemoveAt(i);
                }
            }
        }
    }
}
