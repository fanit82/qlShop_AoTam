using qlShop.models;
using System;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmLoaiChiPhi : Form
    {
        public frmLoaiChiPhi()
        {
            InitializeComponent();
        }
        private void KhoiTaoLuoi()
        {
            int i = 0;
            gridView1.Columns[i].Caption = "Mã";
            gridView1.Columns[i].FieldName = "LoaiChiPhiID";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            i++;
            gridView1.Columns[i].Caption = "Tên loại chi phí";
            gridView1.Columns[i].FieldName = "TenLoaiChiPhi";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "#";
            gridView1.Columns[i].OptionsColumn.FixedWidth = true;
            gridView1.Columns[i].Width = 50;

            gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
        }

        private void frmLoaiChiPhi_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            gridControl1.DataSource = LoaiChiPhiController.GetAllList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtTenLoaiChiPhi.Text == string.Empty)
            {
                MessageBox.Show("Phải nhập tên loại chi phí");
                return;
            }
            LoaiChiPhi item = new LoaiChiPhi();
            item.TenLoaiChiPhi = txtTenLoaiChiPhi.Text;
            LoaiChiPhiController.Add(item);
            txtTenLoaiChiPhi.Text = string.Empty;
            gridControl1.DataSource = LoaiChiPhiController.GetAllList();
            //DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void gr_btn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int introw = gridView1.FocusedRowHandle;
            int intLoaiChiPhiID = -1;
            if (introw>=0)
            {
                intLoaiChiPhiID =Convert.ToInt32(gridView1.GetRowCellValue(introw,"LoaiChiPhiID").ToString());
            }
            if (intLoaiChiPhiID>=0)
            {
                if (e.Button.Caption.ToUpper().Equals("DEL"))
                {
                    if(MessageBox.Show("Bạn có muốn xóa loại chi phí này không?","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.Yes)
                    {
                        LoaiChiPhiController.Del(intLoaiChiPhiID);
                        if (gridView1.GetRowCellValue(introw -1,"LoaiChiPhiID")!=null)
                        {
                            gridControl1.DataSource = LoaiChiPhiController.GetAllList();
                            gridView1.FocusedRowHandle = introw - 1;
                        }
                    }
                }
            }
        }
    }
}
