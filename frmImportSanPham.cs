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
    public partial class frmImportSanPham : Form
    {
        public frmImportSanPham()
        {
            InitializeComponent();
            txtFileName.ReadOnly = true;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Excel file (*.xls)|*.xls"
            };                               
            if (fileDialog.ShowDialog()== DialogResult.OK)
            {
                txtFileName.Text = fileDialog.FileName;
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            string strFileOpen = string.Empty;
            strFileOpen = txtFileName.Text;
            var DS = Utility.ImportExcelXLS(strFileOpen, true);
            gridControl1.DataSource = DS.Tables[0];
            //gridView1.DataSource = DS;
        }
    }
}
