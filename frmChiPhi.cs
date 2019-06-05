using qlShop.models;
using qlShop.qlshop_model;
using System;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmChiPhi : Form
    {
        public ChiPhi editItem { get; set; }
        public string frmMode { get; set; }
        public frmChiPhi()
        {
            InitializeComponent();
            frmMode = string.Empty;
        }

        public void save()
        {
            ChiPhi item = new ChiPhi();
            item.TenChiPhi = txtTenChiPhi.Text.Trim();
            item.NgayChi = dateEditNgayChi.DateTime;
            item.LoaiChiPhiID =Convert.ToInt32( lookupLoaiChiPhi.EditValue.ToString());
            item.TenLoaiChiPhi = lookupLoaiChiPhi.Text;
            item.SoTien = txtSoTien.Value;
            item.GhiChu = txtGhiChu.Text.Trim();
            if ((frmMode.ToUpper().Equals("EDIT"))&&(editItem!=null))
            {
                item.ChiPhiID = editItem.ChiPhiID;
                ChiPhiController.Edit(item);
                editItem = null;
            }
            else
            {
                ChiPhiController.Add(item);
            }
            
        }
        public void LayDSLoaiChiPhi()
        {
            lookupLoaiChiPhi.Properties.DisplayMember = "TenLoaiChiPhi";
            lookupLoaiChiPhi.Properties.ValueMember = "LoaiChiPhiID";
            lookupLoaiChiPhi.Properties.NullValuePrompt = "Chưa chọn loại chi phí";
            lookupLoaiChiPhi.Properties.DataSource = LoaiChiPhiController.GetAllList();
        }

        private void frmChiPhi_Load(object sender, EventArgs e)
        {
            LayDSLoaiChiPhi();
            dateEditNgayChi.DateTime = DateTime.Now;
            if ((frmMode.ToUpper().Equals("EDIT"))&&(this.editItem!=null))
            {
                txtTenChiPhi.Text = editItem.TenChiPhi;
                lookupLoaiChiPhi.EditValue = editItem.LoaiChiPhiID;
                dateEditNgayChi.DateTime = editItem.NgayChi;
                txtSoTien.Value = editItem.SoTien;
                txtGhiChu.Text = editItem.GhiChu;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            save();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void lookupLoaiChiPhi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption.ToUpper().Equals("ADD"))
            {
                frmLoaiChiPhi f = new frmLoaiChiPhi();
                f.ShowDialog(this);
                lookupLoaiChiPhi.Properties.DataSource = LoaiChiPhiController.GetAllList();
                f.Dispose();
                //if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                //{
                //    lookupLoaiChiPhi.Properties.DataSource = LoaiChiPhiController.GetAllList();
                //    f.Dispose();
                //}
            }
        }
    }
}

