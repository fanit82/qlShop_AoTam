using System;
using System.Data;
using System.Windows.Forms;
using qlShop.models;
namespace qlShop
{
    public partial class frmTimSanPham : Form
    {

        //khai bao delegate
        public delegate void SendData(string strData,string strSize = null);
        public SendData SendSanPhamID;

        public DataTable TableSanPham = null;
        DataView dtView = null;
        public frmTimSanPham()
        {
            InitializeComponent();
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
            gridView1.Columns[i].Caption = "Size";
            gridView1.Columns[i].FieldName = "Size";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            //i++;
            //gridView1.Columns[i].Caption = "Nhóm sản phẩm";
            //gridView1.Columns[i].FieldName = "TenNhom";
            //gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Giá bán";
            gridView1.Columns[i].FieldName = "GiaBan";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ### ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Tồn kho";
            gridView1.Columns[i].FieldName = "SoLuong";
            gridView1.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns[i].DisplayFormat.FormatString = "### ### ### ### ##0";
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            //i++;
            //gridView1.Columns[i].Caption = "Nhà sản xuất";
            //gridView1.Columns[i].FieldName = "TenNhaSanXuat";
            //gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "Mã sản phẩm";
            gridView1.Columns[i].FieldName = "SanPhamID";
            gridView1.Columns[i].Visible = false;
            gridView1.Columns[i].OptionsColumn.AllowEdit = false;

            i++;
            gridView1.Columns[i].Caption = "#";
            //gridView1.Columns[i].Name = "CHUC_NANG";
            gridView1.Columns[i].OptionsColumn.FixedWidth = true;
            gridView1.Columns[i].Width = 70;
            //kiểm tra nếu nhân viên thì ẩn chức năng thao tác

            gridView1.OptionsView.ColumnAutoWidth = false;
        }
        private void frmTimSanPham_Load(object sender, System.EventArgs e)
        {
            KhoiTaoLuoi();
            //gridControl1.DataSource = SanPhamController.GetAllList();
            TableSanPham = SanPhamController.TonKhoHeThong();
            dtView = TableSanPham.DefaultView;
            gridControl1.DataSource = dtView;
            gridView1.BestFitColumns();

            treeList1.DataSource = NhomHangController.Getlist();
            treeList1.Columns[0].Caption = "Nhóm Hàng";
            treeList1.Columns[0].FieldName = "TenNhomHang";
            treeList1.Columns[0].OptionsColumn.AllowEdit = false;
            
            treeList1.ParentFieldName = "NhomHangChaID";
            treeList1.KeyFieldName = "NhomHangID";
            treeList1.ExpandAll();
            //treeList1.BestFitColumns();

            treeList1.OptionsView.ShowHorzLines = false;
            treeList1.OptionsView.ShowVertLines = false;

        }

        private void txtSearch_EditValueChanged(object sender, System.EventArgs e)
        {
            gridView1.ActiveFilterString = string.Format("[SanPhamID] like '%{0}%' or TenSanPham like '%{0}%'", txtSearch.Text);
        }

        private void gr_btn_del_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int i = gridView1.FocusedRowHandle;
            if( e.Button.Caption.ToUpper().Equals("CHON"))
            {
                string strSanPhamID = gridView1.GetRowCellValue(i, "SanPhamID").ToString();
                string strSize = gridView1.GetRowCellValue(i, "Size").ToString();
                if (strSize.Equals(string.Empty))
                {
                    strSize = null;
                }
                SendSanPhamID(strSanPhamID, strSize);
            }
        }
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            dtView.RowFilter = string.Empty;
            if (e.Node.Level == 0)
            {
                if (checkEdit_Ton.Checked)
                {
                    dtView.RowFilter = string.Format("SoLuong >0");
                }
            }
            else
            {
                int intNhomHangID = Convert.ToInt32(e.Node[treeList1.KeyFieldName].ToString());
                if (checkEdit_Ton.Checked)
                {
                    
                    dtView.RowFilter = string.Format("NhomHangID={0} And SoLuong > 0", intNhomHangID);
                }
                else
                {
                    dtView.RowFilter = string.Format("NhomHangID={0}", intNhomHangID);
                }

            }
            gridView1.RefreshData();
            gridView1.BestFitColumns();
        }

        private void checkEdit_Ton_CheckedChanged(object sender, EventArgs e)
        {
            dtView.RowFilter = string.Empty;
            if (checkEdit_Ton.Checked)
            {                
                if (treeList1.FocusedNode.Level==0)
                {
                    dtView.RowFilter = string.Format("SoLuong >0");
                }
                else
                {
                    int intNhomHangID = Convert.ToInt32(treeList1.FocusedNode[treeList1.KeyFieldName].ToString());
                    dtView.RowFilter += string.Format("NhomHangID ={0} AND SoLuong > 0", intNhomHangID);
                }                
            }
            else
            {                
                if (treeList1.FocusedNode.Level != 0)
                {
                    int intNhomHangID = Convert.ToInt32(treeList1.FocusedNode[treeList1.KeyFieldName].ToString());
                    dtView.RowFilter += string.Format("NhomHangID ={0}", intNhomHangID);
                }
            }
            gridView1.RefreshData();
            gridView1.BestFitColumns();
        }
    }
}
