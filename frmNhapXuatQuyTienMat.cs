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
    public partial class frmNhapXuatQuyTienMat : Form
    {
        public frmNhapXuatQuyTienMat()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //string strPhanLoai = cbbPhanLoai.SelectedIndex == 0 ? "NT" : "XT";
            if (cbbPhanLoai.SelectedIndex==0) //nhap
            {
                QuyTienMatController.NhapQuyTienMat(string.Empty, txtNgay.DateTime, txtSoTien.Value, "NT", txtGhiChu.Text);    
            }
            else
            {
                QuyTienMatController.XuatQuyTienMat(string.Empty, txtNgay.DateTime, txtSoTien.Value, "XT", txtGhiChu.Text);    
            }
            
            LockForm();
        }
        private void LockForm()
        {
            txtNgay.Properties.ReadOnly = true;
            cbbPhanLoai.Properties.ReadOnly = true;
            txtSoTien.Properties.ReadOnly = true;
            txtGhiChu.Properties.ReadOnly = true;
        }
        private void UnLockForm()
        {
            txtNgay.Properties.ReadOnly = false;
            cbbPhanLoai.Properties.ReadOnly = false;
            txtSoTien.Properties.ReadOnly = false;
            txtGhiChu.Properties.ReadOnly = false;
        }
        private void ResetForm()
        {
            txtNgay.DateTime = DateTime.Now;
            cbbPhanLoai.SelectedIndex = 0;
            txtSoTien.EditValue = 0;
            txtGhiChu.Text = string.Empty;
            txtNgay.Focus();
        }
        private void frmNhapXuatQuyTienMat_Load(object sender, EventArgs e)
        {
            UnLockForm();
            ResetForm();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            UnLockForm();
            ResetForm();
        }
    }
}
