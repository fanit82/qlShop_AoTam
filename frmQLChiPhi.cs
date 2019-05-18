using qlShop.models;
using System;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmQLChiPhi : Form
    {
        public frmQLChiPhi()
        {
            InitializeComponent();
        }

        private void KhoiTaoLuoi()
        {
            int i = 0;
            gridView1.Columns[i].Caption = "Ngày";
            gridView1.Columns[i].FieldName = "NgayChi";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            i++;
            gridView1.Columns[i].Caption = "Chi phí";
            gridView1.Columns[i].FieldName = "TenChiPhi";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Loại chi phí";
            gridView1.Columns[i].FieldName = "LoaiChiPhi";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Số tiền";
            gridView1.Columns[i].FieldName = "SoTien";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ### ###";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Ghi chú";
            gridView1.Columns[i].FieldName = "GhiChu";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;            
        }

        private void frmQLChiPhi_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            gridControl1.DataSource = ChiPhiController.GetAllList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmChiPhi f = new frmChiPhi();
            if (f.ShowDialog(this)== System.Windows.Forms.DialogResult.OK)
            {
                f.Dispose();
                gridControl1.DataSource = ChiPhiController.GetAllList();
            }
        }

        private void gr_btn_del_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int intRow = gridView1.FocusedRowHandle;
            int intChiPhiID = -1;
            if (intRow>=0)
            {
                intChiPhiID = Convert.ToInt32(gridView1.GetRowCellValue(intRow, "ChiPhiID").ToString());
            }
            if ((intChiPhiID>=0)&&((e.Button.Caption.ToUpper().Equals("DEL"))))
            {
                if(MessageBox.Show("Bạn có muốn xóa chi phí này không","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.Yes)
                {
                    ChiPhiController.Del(intChiPhiID);
                    if ((gridView1.GetRowCellValue(intRow-1, "ChiPhiID"))!=null)
                    {
                        gridControl1.DataSource = ChiPhiController.GetAllList();
                        gridView1.FocusedRowHandle = intRow - 1;
                    }
                }
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int intRow = gridView1.FocusedRowHandle;
            int intChiPhiID = -1;
            if (intRow > 0)
            {
                intChiPhiID = Convert.ToInt32(gridView1.GetRowCellValue(intRow, "ChiPhiID").ToString());
            }
            if (intChiPhiID>=0)
            {
                frmChiPhi f = new frmChiPhi();
                f.editItem = ChiPhiController.GetITem(intChiPhiID);
                f.frmMode = "edit";
                f.ShowDialog();
                if ((gridView1.GetRowCellValue(intRow, "ChiPhiID")) != null)
                {                    
                    gridControl1.DataSource = ChiPhiController.GetAllList();
                    gridView1.FocusedRowHandle = intRow;
                }

            }

        }
    }
}
