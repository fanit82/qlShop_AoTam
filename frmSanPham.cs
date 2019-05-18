using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using qlShop.models;
using System;
using System.Windows.Forms;
namespace qlShop
{
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmAddSanPham f = new frmAddSanPham();
            f.ShowDialog();
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            txtSearch.Properties.NullValuePrompt = "Scan mã vạch | Mã sản phẩm | Tên sản phẩm để tìm";
            KhoiTaoLuoi();
            LayDuLieu();
            //kiểm tra phân quyên - nêu là nhân viên thì ko cho chức năng thêm sp
            if (Utility.NguoiSuDung.Roles.ToUpper().Equals(Utility.NHANVIEN.ToUpper()))
            {
                btnAdd.Enabled = false;
                //ẩn các nút chức năng
                //gridView1.Columns["CHUC_NANG"].VisibleIndex = -1;
            }
            else
            {
                btnAdd.Enabled = true;
            }

        }
        private void KhoiTaoLuoi()
        {
            int i = 0;
            gridView1.Columns[i].Caption = "Sản phẩm";
            gridView1.Columns[i].FieldName = "TenSanPham";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            i++;
            gridView1.Columns[i].Caption = "Mã sản phẩm";
            gridView1.Columns[i].FieldName = "SanPhamID";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Nhóm sản phẩm";
            gridView1.Columns[i].FieldName = "TenNhomHang";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Giá bán";
            gridView1.Columns[i].FieldName = "GiaBan";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ### ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Tồn kho";
            gridView1.Columns[i].FieldName = "SLTonKho";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Nhà sản xuất";
            gridView1.Columns[i].FieldName = "TenNhaSanXuat";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Ngừng kinh doanh";
            gridView1.Columns[i].FieldName = "NgungKinhDoanh";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            gridView1.Columns[i].Visible = false;

            i++;
            gridView1.Columns[i].Caption = "Mã sản phẩm";
            gridView1.Columns[i].FieldName = "SanPhamID";
            gridView1.Columns[i].Visible = false;
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Cho xuất âm";
            gridView1.Columns[i].FieldName = "ChoXuatAm";
            gridView1.Columns[i].OptionsColumn.FixedWidth = true;
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            gridView1.Columns[i].Width = 70;

            i++;
            gridView1.Columns[i].Caption = "#";
            //gridView1.Columns[i].Name = "CHUC_NANG";
            gridView1.Columns[i].OptionsColumn.FixedWidth = true;
            gridView1.Columns[i].Width = 70;
            //kiểm tra nếu nhân viên thì ẩn chức năng thao tác

            if (Utility.NguoiSuDung.Roles.ToUpper().Equals(Utility.NHANVIEN.ToUpper()))
            {
                gridView1.Columns[i].Visible = false;
                //ẩn các nút chức năng
                //gridView1.Columns["CHUC_NANG"].VisibleIndex = -1;
            }
            else
            {
                gridView1.Columns[i].Visible = true;
            }
            gridView1.ActiveFilterString = "[NgungKinhDoanh]=false";
            gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;

            gr_btn_del.Buttons[1].Visible = false;//Ẩn nút kinh doanh lại - vì mặc định đang hiển thị các sp kinh doanh
        }

        private void LayDuLieu()
        {
            gridControl1.DataSource = SanPhamController.GetAllList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddSanPham f = new frmAddSanPham();
            f.ShowDialog();
            gridControl1.DataSource = SanPhamController.GetAllList();
        }

        private void gr_btn_del_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int intRowSelect = gridView1.FocusedRowHandle;
            if (intRowSelect >= 0)
            {
                string strSanPhamID = gridView1.GetRowCellValue(intRowSelect, "SanPhamID").ToString();
                switch (e.Button.Caption.ToUpper())
                {
                    case "PAUSE":// ngừng kinh doanh
                        if (MessageBox.Show("Bạn có muốn ngừng kinh doanh sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            SanPhamController.SetTrangThaiKinhDoanh(strSanPhamID,true);//ngung kinh doanh
                            gridControl1.DataSource = SanPhamController.GetAllList();
                        }
                        break;
                    case "START"://  kinh doanh laij
                            SanPhamController.SetTrangThaiKinhDoanh(strSanPhamID,false);//kinh doanh lai
                            gridControl1.DataSource = SanPhamController.GetAllList();
                        break;
                    case "DELETE":
                        if (MessageBox.Show("Bạn có muốn xóa sản phẩm này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            SanPhamController.Del(strSanPhamID);
                            gridControl1.DataSource = SanPhamController.GetAllList();
                        }
                        break;
                    case "COPY": //sao chep san pham
                        SanPham itemCopy = SanPhamController.GetItem(strSanPhamID);
                        if (itemCopy!=null)
                        {
                            frmAddSanPham f = new frmAddSanPham();
                            f.itemCopy = itemCopy;
                            f.formMode = "Copy";
                            f.ShowDialog(this);
                            gridControl1.DataSource = SanPhamController.GetAllList();
                        }
                        break;
                    default:
                        break;
                }
            }

        }

        /// <summary>
        /// Tìm nut trong cot trên lươi theo caption
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="strCaption"></param>
        /// <returns></returns>
        private int FindEditButtonByCaption(RepositoryItemButtonEdit btn,string strCaption)
        {
            int intReturnIndex = -1;
            foreach (EditorButton item in btn.Buttons)
            {
                if (item.Caption.ToUpper().Equals(strCaption.ToUpper()))
                {
                    intReturnIndex = item.Index;
                    break;
                }
            }
            return intReturnIndex;
        }
        private void switchCtr_Toggled(object sender, EventArgs e)
        {
            //tim nut ngung kinh doanh
            int intButtonIndex = -1;
            foreach (EditorButton item in gr_btn_del.Buttons)
            {
                if (item.Caption.ToUpper().Equals("PAUSE"))
                {
                    intButtonIndex = item.Index;                    
                    break;
                }
            }
            //------------------------

            if (switchCtr.IsOn) //đang kinh doanh
            {
                gridView1.ActiveFilterString = "[NgungKinhDoanh]=false";
                gr_btn_del.Buttons[0].Visible = true;//nut ngung kinh doanh hien
                gr_btn_del.Buttons[1].Visible = false;//nut  kinh doanh lai an
                //int intIndex = FindEditButtonByCaption(gr_btn_del, "Pause");
                //if (intIndex>-1)
                //{
                //    gr_btn_del.Buttons[intButtonIndex].Visible = true;
                //}
                //intIndex = FindEditButtonByCaption(gr_btn_del, "Start");
                //if (intIndex > -1)
                //{
                //    gr_btn_del.Buttons[intButtonIndex].Visible = false;
                //}
            }
            else
            {
                gridView1.ActiveFilterString = "[NgungKinhDoanh]=True";
                gr_btn_del.Buttons[0].Visible = false;//nut ngung kinh doanh an
                gr_btn_del.Buttons[1].Visible = true;//nut  kinh doanh lai hien
                //int intIndex = FindEditButtonByCaption(gr_btn_del, "Pause");
                //if (intIndex > -1)
                //{
                //    gr_btn_del.Buttons[intButtonIndex].Visible = false;
                //}
                //intIndex = FindEditButtonByCaption(gr_btn_del, "Start");
                //if (intIndex > -1)
                //{
                //    gr_btn_del.Buttons[intButtonIndex].Visible = true;
                //}

            }
            gridView1.RefreshData();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //sửa thông tin sản phẩm
            int intRow = gridView1.FocusedRowHandle;
            if (intRow>=0)
            {
                string strSanPhamID = gridView1.GetRowCellValue(intRow, "SanPhamID").ToString();
                SanPham item = SanPhamController.GetItem(strSanPhamID);
                if (item!=null)
                {
                    frmAddSanPham f = new frmAddSanPham();
                    f.formMode = "edit";
                    f.itemCopy = item;
                    f.ShowDialog(this);
                    gridControl1.DataSource = SanPhamController.GetAllList(); // làm mới lại dữ liệu
                    gridView1.FocusedRowHandle = intRow;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmBarcode f = new frmBarcode();
            f.MdiParent = this.MdiParent;
            f.Show();
            //gridControl1.DataSource = SanPhamController.GetAllList();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog opf = new SaveFileDialog())
            {
                opf.Title = "Xuất excel";
                opf.Filter = "Execl files (*.xls)|*.xls";
                if( opf.ShowDialog()== System.Windows.Forms.DialogResult.OK)
                {
                    string strFile = opf.FileName;
                    gridView1.ExportToXls(strFile);
                    System.Diagnostics.Process.Start(strFile);
                }                
            }                       
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.ActiveFilterString = string.Format("[SanPhamID] like '%{0}%' or TenSanPham like '%{0}%'", txtSearch.Text);
        }

    }
}
